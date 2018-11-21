using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common
{
    public class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions<CustomContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<Aircraft> Aircraft { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            configureRelations(modelBuilder);
            seed(modelBuilder);
        }

        private void configureRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Flight>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany(a => a.DepartingFlights)
                .HasForeignKey(f => f.DepartureAirportId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DestinationAirport)
                .WithMany(a => a.IncomingFlights)
                .HasForeignKey(f => f.DestinationAirportId);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Aircraft)
                .WithMany(a => a.Flights)
                .HasForeignKey(f => f.AircraftId);
        }

        private void seed(ModelBuilder modelBuilder)
        {
            var bilbaoAirport = new Airport
            {
                Id = 1,
                IATA = "BIO",
                City = "Bilbao",
                Latitude = 43.30110168457031,
                Longitude = 2.9106099605560303
            };

            var malagaAirport = new Airport
            {
                Id = 2,
                IATA = "AGP",
                City = "Malaga",
                Latitude = 36.67490005493164,
                Longitude = 4.499110221862793
            };

            var newYorkAirport = new Airport
            {
                Id = 3,
                IATA = "JFK",
                City = "New York",
                Latitude = 40.63980103,
                Longitude = 73.77890015
            };

            var parisAirport = new Airport
            {
                Id = 4,
                IATA = "CDG",
                City = "Paris",
                Latitude = 49.0127983093,
                Longitude = 2.54999995232
            };

            var airBus320 = new Aircraft
            {
                Id = 1,
                ModelName = "Airbus A320",
                ConsumptionPerKm = 100,
                ConsumptionOnTakeOff = 20
            };

            var boeing757 = new Aircraft
            {
                Id = 2,
                ModelName = "Boeing 757",
                ConsumptionPerKm = 150,
                ConsumptionOnTakeOff = 35
            };

            modelBuilder.Entity<Airport>().HasData(
                bilbaoAirport,
                malagaAirport,
                newYorkAirport,
                parisAirport);

            modelBuilder.Entity<Aircraft>().HasData(
                airBus320,
                boeing757);


            // REF ->https://wildermuth.com/2018/08/12/Seeding-Related-Entities-in-EF-Core-2-1-s-HasData()
            modelBuilder.Entity<Flight>().HasData(
                new
                {
                    Id = 100,
                    DepartureAirportId = 1,
                    DestinationAirportId = 2,
                    AircraftId = 1
                },
                new
                {
                    Id = 101,
                    DepartureAirportId = 3,
                    DestinationAirportId = 4,
                    AircraftId = 2
                },
                new
                {
                    Id = 102,
                    DepartureAirportId = 1,
                    DestinationAirportId = 3,
                    AircraftId = 1
                }
            );
        }
    }
}
