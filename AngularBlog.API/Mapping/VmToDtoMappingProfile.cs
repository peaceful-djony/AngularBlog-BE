using AngularBlog.API.ViewModels;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;

namespace AngularBlog.API.Mapping
{
    public class VmToDtoMappingProfile : Profile
    {
        public VmToDtoMappingProfile()
        {
            #region Users
            
            CreateMap<UserDto, AccountViewModel>();
            CreateMap<AccountViewModel, UserDto>();
            
            CreateMap<AuthDto, AuthViewModel>();
            CreateMap<AuthViewModel, AuthDto>();

            CreateMap<AuthorDto, AuthorViewModel>();
            CreateMap<AuthorViewModel, AuthorDto>();

            #endregion

            CreateMap<PostViewModel, PostDto>();
            CreateMap<PostDto, PostViewModel>();
        }
    }
}