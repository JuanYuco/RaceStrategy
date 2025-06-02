using Microsoft.EntityFrameworkCore;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Tire> Tires { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<TireByStrategy> TireByStrategies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
