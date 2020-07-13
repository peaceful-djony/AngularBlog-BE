using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.DTO;
using AutoMapper;

namespace AngularBlog.Infrastructure.Data.Mapping
{
    public class DtoToEntityMappingProfile: Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<User, AuthDto>();
            CreateMap<AuthDto, User>();
        }
    }
}