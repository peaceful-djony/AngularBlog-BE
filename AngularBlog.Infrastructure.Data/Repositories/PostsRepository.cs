using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.Contexts;

namespace AngularBlog.Infrastructure.Data.Repositories
{
    public class PostsRepository : BaseRepository<int, Post>, IPostRepository
    {
        public PostsRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}