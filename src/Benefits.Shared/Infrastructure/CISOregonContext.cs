using Benefits.Shared.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Benefits.Shared.Infrastructure
{
    public class CISOregonContext : DbContext
    {
        // DbContextOptions for CISOregonContext are assigned in Startup.cs.
        public CISOregonContext(DbContextOptions<CISOregonContext> options) : base(options)
        {
        }

        // Context objects:
        public DbSet<CMS> CMS { get; set; }
        public DbSet<JsonDataSource> JsonDataSource { get; set; }
    }
}