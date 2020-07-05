using System.Collections.Generic;
using AngularBlog.API.ViewModels;
using AngularBlog.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserRepository userRepository;

        public AccountController(
            ILogger<AccountController> logger,
            IUserRepository userRepository
            )
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return null;
        }
    }
}