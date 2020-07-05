using AngularBlog.Domain.Models;

namespace AngularBlog.Services.Interfaces
{
    public interface IPublisher
    {
        bool NewPost(Post post);
    }
}