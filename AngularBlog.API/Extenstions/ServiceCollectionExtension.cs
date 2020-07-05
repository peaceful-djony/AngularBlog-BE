using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AngularBlog.API.Extenstions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}