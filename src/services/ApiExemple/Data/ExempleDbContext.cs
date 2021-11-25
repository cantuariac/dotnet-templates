using ApiExemple.Models;
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiExemple.Data
{
    public class ExempleDbContext : CoreDbContext<ExempleDbContext>
    {
        public ExempleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
