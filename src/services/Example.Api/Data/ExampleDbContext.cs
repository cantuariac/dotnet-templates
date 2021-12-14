using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Example.Api.Data
{
    public class ExampleDbContext : CoreDbContext<ExampleDbContext>
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
