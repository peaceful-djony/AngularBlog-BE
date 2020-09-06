using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Services
{
    // TODO move to Identity Server 4
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> logger;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public AuthService(
            ILogger<AuthService> logger,
            IUsersRepository usersRepository,
            IMapper mapper
        )
        {
            this.logger = logger;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<AuthDto> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                logger.LogWarning($"Empty {username} or {password}");
                // TODO Null Object
                return null;
            }

            var user = await usersRepository.GetByCredentialsAsync(username, password);
            if (user == null)
            {
                logger.LogTrace($"User {username} with {password} was not found");
                // TODO Null Object
                return null;
            }
            
            return mapper.Map<AuthDto>(user);
        }
    }
}