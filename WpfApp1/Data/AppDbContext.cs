using Microsoft.EntityFrameworkCore;
using WpfApp1.model;

namespace WpfApp1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MedCart> MedCarts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionResult> InspectionResults { get; set; }
        public DbSet<Doctor> Doctors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = "Host=localhost;Port=5432;Database=med-osm;Username=postgres;Password=*Walpy";
            builder.UseNpgsql(connectionString);
            builder.EnableDetailedErrors();
            
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

