using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.API.ViewModels;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Controllers
{
    /// <summary>
    ///     AccountController is provide secure access to Users information
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;
        
        // TODO don't use repository from Controller directly
        private readonly IUserRepository userRepository;

        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IUserRepository userRepository
            )
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        /// <summary>
        ///     Get method returns full list of users
        /// </summary>
        /// <returns>accounts</returns>
        [HttpGet]
        public async Task<IEnumerable<AccountViewModel>> GetAsync()
        {
            var users = await userRepository.GetAllAsync();
            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            var res = mapper.Map<IEnumerable<AccountViewModel>>(userDtos);
            return res;
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
            var user = await userRepository.GetAsync(id);
            var userDto = mapper.Map<UserDto>(user); 
            var res = mapper.Map<AccountViewModel>(userDto);
            return res;
        }
    }
}