using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;

namespace AngularBlog.Infrastructure.Data.Mapping
{
    public class DtoToEntityMappingProfile: Profile
    {
        public DtoToEntityMappingProfile()
        {
            #region User

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<User, AuthorDto>();
            CreateMap<AuthorDto, User>();
            
            CreateMap<User, AuthDto>();
            CreateMap<AuthDto, User>();

            #endregion
            
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}