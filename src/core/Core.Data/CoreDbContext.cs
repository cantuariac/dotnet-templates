
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class CoreDbContext<TContext> : DbContext
    {
        public CoreDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
