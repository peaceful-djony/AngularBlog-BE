using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Services
{
    // TODO summary
    // TODO move to Identity Server 4
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> logger;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(
            ILogger<UsersService> logger,
            IUsersRepository usersRepository,
            IMapper mapper
        )
        {
            this.logger = logger;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await usersRepository.GetAllAsync();
            if (users == null)
            {
                logger.LogError("Null Enumerable");
                // TODO Null Object
                return null;
            }
            
            if (!users.Any())
            {
                logger.LogTrace("Empty User list");
                // TODO Null Object
                return null;
            }
            
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);

            return mapper.Map<UserDto>(user);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int authorId)
        {
            var author = await GetUserByIdAsync(authorId);

            return mapper.Map<AuthorDto>(author);
        }

        private async Task<User> GetUserByIdAsync(int userId)
        {
            if (userId < 1)
            {
                logger.LogWarning($"Invalid User Id {userId}");
                // TODO Null Object
                return null;
            }

            var user = await usersRepository.GetAsync(userId);
            if (user == null)
            {
                // TODO Null Object
                logger.LogTrace($"User with User Id {userId} was not found");
            }

            return user;
        }
    }
}