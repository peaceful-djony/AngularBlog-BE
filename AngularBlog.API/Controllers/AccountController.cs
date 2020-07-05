using System.Collections.Generic;
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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper mapper;
        
        // TODO don't use repository from Controller directly
        private readonly IUserRepository userRepository;

        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IUserRepository userRepository
            )
        {
            _logger = logger;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<AccountViewModel> Get()
        {
            var users = userRepository.GetAll();
            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            var res = mapper.Map<IEnumerable<AccountViewModel>>(userDtos);
            return res;
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public AccountViewModel GetById(int id)
        {
            var user = userRepository.Get(id);
            var userDto = mapper.Map<UserDto>(user); 
            var res = mapper.Map<AccountViewModel>(userDto);
            return res;
        }
    }
}