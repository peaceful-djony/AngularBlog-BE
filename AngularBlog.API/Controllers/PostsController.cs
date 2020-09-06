using System.Threading.Tasks;
using AngularBlog.API.ViewModels;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularBlog.API.Controllers
{
    /// <summary>
    ///     PostsController provide secure access to Posts
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostsController(
            IPostService postService,
            IMapper mapper
        )
        {
            this.postService = postService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postService.GetPostsAsync();
            return Ok(posts);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await postService.GetPostByIdAsync(id);
            return Ok(post);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]PostViewModel post)
        {
            var postDto = mapper.Map<PostDto>(post);
            var res = await postService.Create(postDto);
            
            // TODO format of IAction Result
            return Ok(res);
        }
    }
}