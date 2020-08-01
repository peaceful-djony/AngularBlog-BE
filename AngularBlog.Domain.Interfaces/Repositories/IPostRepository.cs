using AngularBlog.Domain.Models;

namespace AngularBlog.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IBaseRepository<int, Post>
    {   
    }
}