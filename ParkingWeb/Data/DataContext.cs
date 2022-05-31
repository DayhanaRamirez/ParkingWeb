using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingWeb.Data.Entities;

namespace ParkingWeb.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Campus> Campuses {get; set;}

        public DbSet<ParkingLot> ParkingLots { get; set; }

        public DbSet<ParkingCell> ParkingCells { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Restriction> Restrictions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.LicensePlate).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(v => v.Name).IsUnique();
            modelBuilder.Entity<Restriction>().HasIndex(v => v.Day).IsUnique();
            modelBuilder.Entity<Campus>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<ParkingLot>().HasIndex("Name", "CampusId").IsUnique();
            modelBuilder.Entity<ParkingCell>().HasIndex("Name", "ParkingLotId").IsUnique();
        }

    }
}
