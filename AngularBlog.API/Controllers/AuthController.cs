using System.Threading.Tasks;
using AngularBlog.API.ViewModels;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper mapper;
        
        // TODO don't use repository from Controller directly
        private readonly IUserRepository userRepository;

        public AuthController(
            ILogger<AuthController> logger,
            IMapper mapper,
            IUserRepository userRepository
        )
        {
            _logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        
        [HttpPost]
        public async Task<AccountViewModel> Auth(AccountViewModel account)
        {
            //TODO check pass
            var user = await userRepository.GetFilteredAsync(account.Email);
            var userDto = mapper.Map<UserDto>(user); 
            var res = mapper.Map<AccountViewModel>(userDto);
            return res;
        }
    }
}