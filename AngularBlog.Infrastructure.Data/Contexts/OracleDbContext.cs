using Microsoft.EntityFrameworkCore;

namespace AngularBlog.Infrastructure.Data.Contexts
{
    public class OracleDbContext : PostDbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }
    }
}