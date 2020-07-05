using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Contexts
{
    public class PostContext : DbContext
    {   
        // TODO more configurable
        private string connectionString = "server=localhost;user id=ciiva;Pwd=ciiva;persistsecurityinfo=True;database=angular_blog;allowuservariables=True";
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
    }
}