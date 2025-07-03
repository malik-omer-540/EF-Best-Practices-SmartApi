using EF_Best_Practices_SmartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Best_Practices_SmartApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Index on Email for fast lookups
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email);
        }
    }
}
