using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using AngularBlog.API.Extensions;
using AngularBlog.API.ViewModels;
using AngularBlog.Common;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AngularBlog.API.Controllers
{
    /// <summary>
    ///     AuthController responsibility is authorisation
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IExpirationService expirationService;
        private readonly IOptions<AppSettings> appSettings;
        private readonly ILogger<AuthController> logger;

        /// <summary>
        ///     Constructor for AuthController
        /// </summary>
        /// <param name="logger">Instance of type <see cref="ILogger"/> to log activity</param>
        /// <param name="authService">Authentication Service of type <see cref="IAuthService"/></param>
        /// <param name="expirationService">Expiration Service of type <see cref="IExpirationService"/></param>
        /// <param name="appSettings">String typed settings for application</param>
        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService,
            IExpirationService expirationService,
            IOptions<AppSettings> appSettings
        )
        {
            this.logger = logger;
            this.authService = authService;
            this.expirationService = expirationService;
            this.appSettings = appSettings;
        }

        /// <summary>
        ///     Post method do the authorisation, based on JWT
        /// </summary>
        /// <param name="account">VM represent data to login</param>
        /// <returns>AuthViewModel</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel account)
        {
            logger.LogTrace($"Account {account.Email} tying to login");

            var user = await authService.LoginAsync(account.Email, account.Password);
            if (user == null)
                // TODO to resources
                return BadRequest(new
                {
                    message = "Username or password is incorrect",
                    code = "INVALID_CREDENTIALS"
                });

            var expiresIn = expirationService.GetExpiration();
            var tokenStr = GetJwt(user, expiresIn);

            return Ok(new AuthViewModel
            {
                Token = tokenStr,
                ExpiresIn = expiresIn.ToString(CultureInfo.InvariantCulture)
            });
        }

        private string GetJwt(AuthDto user, DateTime expiresIn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = appSettings.GetSecretKey();
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }
    }
}