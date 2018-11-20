using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using GeoCoordinatePortable;
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
            var bilbaoAirport = new Airport
            {
                IATA = "BIO",
                City = "Bilbao",
                GeoPosition = new GeoCoordinate(43.30110168457031, 2.9106099605560303)
            };

            var malagaAirport = new Airport
            {
                IATA = "AGP",
                City = "Malaga",
                GeoPosition = new GeoCoordinate(36.67490005493164, 4.499110221862793)
            };

            var newYorkAirport = new Airport
            {
                IATA = "JFK",
                City = "New York",
                GeoPosition = new GeoCoordinate(40.63980103, 73.77890015)
            };

            var parisAirport = new Airport
            {
                IATA = "CDG",
                City = "Paris",
                GeoPosition = new GeoCoordinate(49.0127983093, 2.54999995232)
            };

            var airBus320 = new Aircraft
            {
                ModelName = "Airbus A320",
                ConsumptionPerKm = 100,
                ConsumptionOnTakeOff = 20
            };

            var boeing757 = new Aircraft
            {
                ModelName = "Boeing 757",
                ConsumptionPerKm = 150,
                ConsumptionOnTakeOff = 35
            };


            modelBuilder.Entity<Airport>().HasData(
                bilbaoAirport,
                malagaAirport,
                newYorkAirport,
                parisAirport
            );

            modelBuilder.Entity<Aircraft>().HasData(
                airBus320,
                boeing757
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight(bilbaoAirport, malagaAirport, airBus320),
                new Flight(bilbaoAirport, malagaAirport, boeing757),
                new Flight(newYorkAirport, parisAirport, airBus320),
                new Flight(bilbaoAirport, parisAirport, boeing757),
                new Flight(malagaAirport, newYorkAirport, boeing757)
            );
        }
    }
}
