using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Services
{
    // TODO summary
    // TODO move to specific project
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AuthService(
            ILogger<AuthService> logger,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<AuthDto> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                logger.LogWarning($"Empty {username} or {password}");
                return null;
            }

            var user = await userRepository.GetByCredentialsAsync(username, password);
            if (user == null)
            {
                logger.LogTrace($"User {username} with {password} was not found");
                return null;
            }
            
            return mapper.Map<AuthDto>(user);
        }
    }
}