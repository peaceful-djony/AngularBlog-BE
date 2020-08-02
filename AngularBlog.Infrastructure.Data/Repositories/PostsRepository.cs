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

        public override async Task<Post> GetAsync(int id)
        {
            var res = await EntitiesSet.Include(u => u.Author).FirstOrDefaultAsync(u => u.Id.Equals(id));
            return res;
        }
    }
}