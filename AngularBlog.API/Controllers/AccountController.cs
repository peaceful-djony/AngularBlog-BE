using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.API.ViewModels;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Controllers
{
    /// <summary>
    ///     AccountController provide secure access to Users information
    /// TODO IAction vs Type: https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;

        private readonly IUsersService usersService;
        private readonly IScopeInfoService scopeInfo;

        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IUsersService usersService,
            IScopeInfoService scopeInfo
        )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.usersService = usersService;
            this.scopeInfo = scopeInfo;
        }

        /// <summary>
        ///     Get method returns full list of users
        /// </summary>
        /// <returns>accounts</returns>
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAsync()
        {
            var users = await usersService.GetAllAsync();
            return mapper.Map<IEnumerable<AccountViewModel>>(users);
        }
        
        /// <summary>
        ///     Get method returns particular user by id
        /// </summary>
        /// <param name="id">Unique identifier of user</param>
        /// <returns>account</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<AccountViewModel> GetById(int id)
        {
            var user = await usersService.GetByIdAsync(id);
            return mapper.Map<AccountViewModel>(user);
        }
        
        /// <summary>
        ///     Returns particular Author from token
        /// </summary>
        /// <returns>author from token</returns>
        [HttpGet]
        [Route("author")]
        public async Task<AuthorViewModel> GetAuthor()
        {
            var author = await usersService.GetAuthorByIdAsync(scopeInfo.UserId);
            return mapper.Map<AuthorViewModel>(author);
        }
    }
}