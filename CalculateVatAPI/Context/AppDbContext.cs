using CalculateVatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculateVatAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryVat> CountriesVats { get; set; }
    }
}
