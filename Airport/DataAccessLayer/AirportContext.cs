using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AirportContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftType> AircraftsTypes { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().HasOne<AircraftType>(s => s.AircraftType).WithOne(ad => ad.Aircraft)
                .HasForeignKey<AircraftType>(ad => ad.AircraftId);

            modelBuilder.Entity<Crew>().HasOne<Pilot>(s => s.Pilot).WithOne(ad => ad.Crew)
                .HasForeignKey<Pilot>(ad => ad.CrewId);

            modelBuilder.Entity<Departure>().HasOne<Flight>(s => s.Flight).WithOne(ad => ad.DepartureEvent)
                .HasForeignKey<Flight>(ad => ad.DepartureId);

            modelBuilder.Entity<Departure>().HasOne<Crew>(s => s.Crew).WithOne(ad => ad.Departure)
                .HasForeignKey<Crew>(ad => ad.DepartureId);

            modelBuilder.Entity<Departure>().HasOne<Aircraft>(s => s.Aircraft).WithOne(ad => ad.Departure)
                .HasForeignKey<Aircraft>(ad => ad.DepartureId);

            modelBuilder.Entity<Ticket>().HasOne<Flight>(s => s.Flight).WithMany(g => g.Tickets)
                .HasForeignKey(s => s.FlightId);

            modelBuilder.Entity<Ticket>().HasOne<Flight>(s => s.Flight).WithMany(g => g.Tickets)
                .HasForeignKey(s => s.FlightId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stewardess>().HasOne<Crew>(s => s.Crew).WithMany(g => g.Stewardesses)
                .HasForeignKey(s => s.CrewId);

            modelBuilder.Entity<Stewardess>().HasOne<Crew>(s => s.Crew).WithMany(g => g.Stewardesses)
                .HasForeignKey(s => s.CrewId).OnDelete(DeleteBehavior.SetNull);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Airportdb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("", b => b.MigrationsAssembly("PresentationLayer"));
        }
    }
}


