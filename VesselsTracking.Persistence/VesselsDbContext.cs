using Microsoft.EntityFrameworkCore;
using VesselsTracking.Domain;

namespace VesselsTracking.Persistence
{
    public class VesselsDbContext : DbContext
    {
        public VesselsDbContext(DbContextOptions<VesselsDbContext> options) : base(options)
        {
        }

        public DbSet<TrackedVessel> TrackedVessels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackedVessel>()
                .HasKey(x => x.Id);
        }
    }
}