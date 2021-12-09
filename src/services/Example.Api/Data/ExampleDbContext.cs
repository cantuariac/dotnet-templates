using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Data
{
    public class ExampleDbContext : CoreDbContext<ExampleDbContext>
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
