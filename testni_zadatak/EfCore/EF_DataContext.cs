using Microsoft.EntityFrameworkCore;

namespace testni_zadatak.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<GmlFeature> GmlFeatures { get; set; }
        public DbSet<GmlCoordinate> GmlCoordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GmlFeature>()
                .HasMany(f => f.Coordinates)
                .WithOne(c => c.GmlFeature)
                .HasForeignKey(c => c.GmlFeatureId);
        }

    }
}
