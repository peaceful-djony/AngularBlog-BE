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
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(
            ILogger<UserService> logger,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            if (userId < 1)
            {
                logger.LogWarning($"Invalid User Id {userId}");
                return null;
            }

            var user = await userRepository.GetAsync(userId);
            if (user == null)
            {
                logger.LogTrace($"User with User Id {userId} was not found");
                return null;
            }
            
            return mapper.Map<UserDto>(user);
        }
    }
}