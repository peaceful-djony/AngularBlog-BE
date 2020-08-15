using System.Collections.Generic;
using System.Threading.Tasks;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.DTO;
using AngularBlog.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AngularBlog.API.Services
{
    public class PostService : IPostService
    {
        private readonly ILogger<PostService> logger;
        private readonly IMapper mapper;
        private readonly IPostsRepository postsRepository;
        private readonly IScopeInfoService scopeInfoService;

        public PostService(
            ILogger<PostService> logger,
            IMapper mapper,
            IPostsRepository postsRepository,
            IScopeInfoService scopeInfoService 
        )
        {
            this.logger = logger;
            this.postsRepository = postsRepository;
            this.scopeInfoService = scopeInfoService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var posts = await postsRepository.GetAllAsync();
            return mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var posts = await postsRepository.GetAsync(id);
            return mapper.Map<PostDto>(posts);
        }

        public async Task<bool> Create(PostDto post)
        {
            post.Author.Id = scopeInfoService.UserId;
            var newPost = mapper.Map<Post>(post);
            return await postsRepository.CreateAsync(newPost);
        }
    }
}