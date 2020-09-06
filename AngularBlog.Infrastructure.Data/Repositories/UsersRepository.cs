using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class UsersRepository : BaseRepository<int, User>, IUsersRepository
    {
        public UsersRepository(PostDbContext dbContext) : base(dbContext)
        {}

        #region IUsersRepository

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var res = await EntitiesSet.Include(u => u.Posts).ToListAsync();
            return res;
        }
        
        public override async Task<User> GetAsync(int id)
        {
            var res = await EntitiesSet.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id.Equals(id));
            return res;
        }

        #endregion

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