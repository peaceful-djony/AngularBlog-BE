using AngularBlog.API.Extensions;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AngularBlog.API
{
    public class Startup
    {
        readonly string LocalhostAllowSpecificOrigins = "_localhostAllowSpecificOrigins";

        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            this.env = env;
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();

            services.AddRepositories();
            
            //TODO implement JWT 

            //TODO https://docs.microsoft.com/ru-ru/aspnet/core/security/cors?view=aspnetcore-3.1
            services.AddCors(options =>
            {
                options.AddPolicy(name: LocalhostAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddPostContext(configuration);
            
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Angular Blog API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, PostDbContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Angular Blog API");
            });

            //TODO
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(LocalhostAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}