using CoronaStatsAustria.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaStatsAustria.DataAccess
{
    public class CovidDataContext : DbContext
    {
        public DbSet<FederalState> States { get; set; } = null!;

        public DbSet<District> Districts { get; set; } = null!;

        public DbSet<CovidStats> CovidStatistics { get; set; } = null!;

        public CovidDataContext(DbContextOptions<CovidDataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>()
                .HasOne(d => d.State)
                .WithMany(s => s.Districts)
                .HasForeignKey(d => d.StateId);

            modelBuilder.Entity<CovidStats>()
                .HasOne(c => c.District)
                .WithOne(d => d.CovidStatistics)
                .HasForeignKey<CovidStats>(c => c.DistrictId);
        }
    }
}
