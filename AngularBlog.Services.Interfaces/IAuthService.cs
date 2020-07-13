using System.Threading.Tasks;
using AngularBlog.Infrastructure.Data.DTO;

namespace AngularBlog.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> LoginAsync(string username, string password);
    }
}