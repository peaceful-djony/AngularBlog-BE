using AngularBlog.API.Mapping;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.Mapping;
using AngularBlog.Infrastructure.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AngularBlog.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
        
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new VmToDtoMappingProfile());
                mc.AddProfile(new DtoToEntityMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            return services;
        }
    }
}