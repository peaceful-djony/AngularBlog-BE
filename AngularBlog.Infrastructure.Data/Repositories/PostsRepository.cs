using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class PostsRepository : BaseRepository<int, Post>, IPostsRepository
    {
        public PostsRepository(PostDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await EntitiesSet.Include(p => p.Author)
                .ToListAsync();
        }
        
        public override async Task<Post> GetAsync(int id)
        {
            return await EntitiesSet.Include(p => p.Author)
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
        }
    }
}