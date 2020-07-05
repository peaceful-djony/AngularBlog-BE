using AngularBlog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data
{
    public class AccountContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}