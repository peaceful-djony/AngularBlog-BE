using AngularBlog.Domain.Models;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IPostsRepository : IBaseRepository<int, Post>
    {   
    }
}