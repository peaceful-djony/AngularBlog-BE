using AngularBlog.Domain.Models;
using AngularBlog.Infrastructure.Data.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Contexts
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
    }
}