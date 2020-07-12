using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Contexts
{
    public class MySqlDbContext : PostDbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }
    }
}