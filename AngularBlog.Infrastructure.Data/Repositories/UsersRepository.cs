using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class UsersRepository : BaseRepository<int, User>, IUserRepository
    {
        public UsersRepository(PostDbContext dbContext) : base(dbContext)
        {}

        #region IUsersRepository

        public async Task<User> GetFilteredAsync(string email)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByCredentialsAsync(string email, string password)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }        

        #endregion
    }
}