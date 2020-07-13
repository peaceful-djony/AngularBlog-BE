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
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IExpirationService expirationService;
        private readonly IOptions<AppSettings> appSettings;
        private readonly ILogger<AuthController> logger;

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
        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel account)
        {
            logger.LogTrace($"Account {account.Email} tying to login");

            var user = await authService.LoginAsync(account.Email, account.Password);
            if (user == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            var tokenStr = GetJwt(user);

            return Ok(new AuthViewModel()
            {
                Id = user.Id,
                Token = tokenStr
            });
        }

        private string GetJwt(AuthDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = appSettings.GetSecretKey();
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = expirationService.GetExpiration(),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }
    }
}