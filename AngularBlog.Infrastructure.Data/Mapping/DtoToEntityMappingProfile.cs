using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;

namespace AngularBlog.Infrastructure.Data.Mapping
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            #region Users

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .ForMember(
                    dest => dest.Posts,
                    opt => opt.Ignore());

            CreateMap<User, AuthorDto>();
            CreateMap<AuthorDto, User>()
                .ForMember(
                    dest => dest.Posts,
                    opt => opt.Ignore());

            CreateMap<User, AuthDto>();
            CreateMap<AuthDto, User>()
                .ForMember(
                    dest => dest.Posts,
                    opt => opt.Ignore());

            #endregion

            #region Posts
            
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>()
                .ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom(e=>e.Author.Id))
                .ForMember(
                    dest => dest.Author,
                    opt => opt.Ignore());

            #endregion
        }
    }
}