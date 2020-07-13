using System.Threading.Tasks;
using AngularBlog.Infrastructure.Data.DTO;

namespace AngularBlog.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int userId);
    }
}