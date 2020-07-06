using AngularBlog.API.Extensions;
using AngularBlog.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AngularBlog.API
{
    public class Startup
    {
        readonly string LocalhostAllowSpecificOrigins = "_localhostAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();

            services.AddRepositories();

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

            services.AddDbContext<PostContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //TODO
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(LocalhostAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}