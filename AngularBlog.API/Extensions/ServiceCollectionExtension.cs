using System;
using AngularBlog.API.Mapping;
using AngularBlog.Common;
using AngularBlog.Domain.Interfaces.Repositories;
using AngularBlog.Infrastructure.Data.Contexts;
using AngularBlog.Infrastructure.Data.Mapping;
using AngularBlog.Infrastructure.Data.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AngularBlog.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UsersRepository>();

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
        
        public static IServiceCollection AddPostContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbType = configuration[Constants.DbTypeKey];
            var connectionStringKey = string.Format(Constants.ConnectionStringTemplate, dbType);
            var connectionString = configuration[connectionStringKey];
            
            switch (dbType)
            {
                case Constants.DbTypes.MySql:
                    services.AddDbContextPool<PostDbContext, MySqlDbContext>(options =>
                    {
                        options.UseMySql(connectionString);
                    });
                    break;
                case Constants.DbTypes.Oracle:
                    services.AddDbContextPool<PostDbContext, OracleDbContext>(options =>
                    {
                        options.UseOracle(connectionString);
                    });
                    break;
                default:
                    throw new Exception($"The value \"{dbType}\" is unexpected DB Type");
            }

            return services;
        }
    }
}