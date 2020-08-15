using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Infrastructure.Data.DTO;

namespace AngularBlog.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<bool> Create(PostDto post);
    }
}