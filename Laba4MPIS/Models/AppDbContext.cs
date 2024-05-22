using Laba4MPIS.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace Laba4MPIS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<PriceAudit> PriceAudits { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
