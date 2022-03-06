using Microsoft.EntityFrameworkCore;
using standardAPI.Models;

namespace standardAPI.Database
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options) { }
        public DbSet<FxRate> Rates => Set<FxRate>();
    }
}
