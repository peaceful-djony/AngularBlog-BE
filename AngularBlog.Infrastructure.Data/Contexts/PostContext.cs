using AngularBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}