using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using AngularBlog.API.Extensions;
using AngularBlog.API.Services;
using AngularBlog.Common;
using AngularBlog.Infrastructure.Data.Contexts;
using AngularBlog.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AngularBlog.API
{
    public class Startup
    {
        private const string Version = "v1"; // TODO to config

        readonly string LocalhostAllowSpecificOrigins = "_localhostAllowSpecificOrigins";

        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;

        public Startup(
            IWebHostEnvironment env,
            IConfiguration configuration
        )
        {
            this.env = env;
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapper();

            services.AddRepositories();

            services.AddSingleton<IExpirationService, ExpirationService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

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

            // configure strongly typed app settings object
            var appSettingsSection = configuration.GetSection(Constants.AppSettingsKey);
            services.Configure<AppSettings>(appSettingsSection);

            ConfigureJwt(services, appSettingsSection);

            services.AddPostContext(configuration);

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc(Version, new OpenApiInfo
                {
                    Title = "Angular Blog API",
                    Version = Version
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                sw.IncludeXmlComments(xmlPath);
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
            app.UseSwaggerUI(c => { c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", "Angular Blog API"); });

            //TODO
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(LocalhostAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // TODO check setup
        private void ConfigureJwt(
            IServiceCollection services,
            IConfiguration appSettingsSection
        )
        {
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = appSettings.GetSecretKey();
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context => await JwtValidated(context)
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                    };
                });
        }

        #region JWT

        private async Task JwtValidated(TokenValidatedContext context)
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            var userIdStr = context.Principal.Identity.Name;
            if (!int.TryParse(userIdStr, out var userId))
            {
                //TODO logger.LogError($"User {userIdStr} have invalid Id");
                return;
            }

            var user = await userService.GetByIdAsync(userId);
            if (user == null)
            {
                context.Fail("Unauthorized");
            }
        }

        #endregion
    }
}