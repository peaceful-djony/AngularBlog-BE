using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Infrastructure.Data.DTO;

namespace AngularBlog.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int userId);
        Task<AuthorDto> GetAuthorByIdAsync(int authorId);
    }
}