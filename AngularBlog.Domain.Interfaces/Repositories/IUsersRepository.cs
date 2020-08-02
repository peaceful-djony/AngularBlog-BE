using System.Threading.Tasks;
using AngularBlog.Domain.Models;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IBaseRepository<int, User>
    {
        Task<User> GetFilteredAsync(string email); //TODO use expression instead of fields
        Task<User> GetByCredentialsAsync(string email, string password);
    }
}