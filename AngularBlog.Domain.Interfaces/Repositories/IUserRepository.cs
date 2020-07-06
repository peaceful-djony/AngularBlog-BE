using System.Threading.Tasks;
using AngularBlog.Domain.Models;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        //TODO use expression instead of fields
        Task<User> GetFilteredAsync(string email);
    }
}