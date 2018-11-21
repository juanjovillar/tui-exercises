using Domain.Airports;
using Infrastructure.Airports;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Infrastructure.UnitTest.Flights
{
    public class AirportRepositoryTests
    {
        private readonly Airport _airport;

        public AirportRepositoryTests()
        {
            _airport = new Airport()
            {
                Id = 1,
                IATA = "TestAirport",
                City = "TestCity",
                Latitude = 43.30110168457031,
                Longitude = 2.9106099605560303
            };
        }

        [Fact]
        public void Should_Add_Airport()
        {
            // Given
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseInMemoryDatabase("TestDB")
                .EnableSensitiveDataLogging()
                .Options;

            // When
            using (var context = new CustomContext(options))
            {
                var repository = new AirportsRepository(context);
                var uow = new UnitOfWork(context);

                repository.Add(_airport);
                uow.Save();
            }

            // Then
            using (var context = new CustomContext(options))
            {
                var repository = new AirportsRepository(context);

                var result = repository.GetAll().Single(x => x.IATA == _airport.IATA);

                Assert.NotNull(result);
            }
        }
    }
}
