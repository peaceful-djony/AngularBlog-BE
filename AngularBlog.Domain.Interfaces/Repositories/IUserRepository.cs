using System.Threading.Tasks;
using AngularBlog.Domain.Models;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        Task<User> GetFilteredAsync(string email); //TODO use expression instead of fields
        Task<User> GetByCredentialsAsync(string email, string password);
    }
}