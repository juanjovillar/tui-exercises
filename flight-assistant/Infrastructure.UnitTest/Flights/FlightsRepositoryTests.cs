using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using Infrastructure.Common;
using Infrastructure.Flights;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Infrastructure.Aircrafts;
using Infrastructure.Airports;
using Xunit;

namespace Infrastructure.UnitTest.Flights
{
    public class FlightsRepositoryTests
    {
        private readonly Airport _departureAirport;
        private readonly Airport _destinationAirport;
        private readonly Aircraft _aircraft;

        public FlightsRepositoryTests()
        {
            _departureAirport = new Airport
            {
                Id = 100,
                IATA = "DEP",
                City = "Departure",
                Latitude = 36.67490005493164,
                Longitude = 4.499110221862793
            };

            _destinationAirport = new Airport
            {
                Id = 200,
                IATA = "DES",
                City = "Destination",
                Latitude = 43.30110168457031,
                Longitude = 2.9106099605560303
            };

            _aircraft = new Aircraft
            {
                Id = 100,
                ModelName = "Aircraf 1000",
                ConsumptionPerKm = 150,
                ConsumptionOnTakeOff = 35
            };
        }

        [Fact]
        public void Should_Add_Flight()
        {
            // Given
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseInMemoryDatabase("TestDB")
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging()
                .Options;

            var flightId = 100;

            // When
            using (var context = new CustomContext(options))
            {
                var uow = new UnitOfWork(context);
                var repository = new FlightsRepository(context);
                var airportRepository = new AirportsRepository(context);
                var aircraftRepository = new AircraftRepository(context);

                airportRepository.Add(_departureAirport);
                airportRepository.Add(_destinationAirport);
                aircraftRepository.Add(_aircraft);
                uow.Save();

                var flight = new Flight(_departureAirport, _destinationAirport, _aircraft){ Id = 100};

                repository.Add(flight);
                uow.Save();
            }

            // Then
            using (var context = new CustomContext(options))
            {
                var repository = new FlightsRepository(context);
                var result = repository.GetAll().Single(x => x.Id == flightId);

                Assert.NotNull(result);
                Assert.Equal(_departureAirport.Id, result.DepartureAirport.Id);
            }
        }
    }
}
