using Domain.Aircrafts;
using Infrastructure.Aircrafts;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Infrastructure.UnitTest.Flights
{
    public class AircraftRepositoryTests
    {
        private readonly Aircraft _aircraft;

        public AircraftRepositoryTests()
        {
            _aircraft = new Aircraft
            {
                ModelName = "Test Aircraft 1000",
                ConsumptionPerKm = 150,
                ConsumptionOnTakeOff = 35
            };
        }

        [Fact]
        public void Should_Add_Aircraft()
        {
            // Given
            var options = new DbContextOptionsBuilder<CustomContext>()
                .UseInMemoryDatabase("TestDB")
                .EnableSensitiveDataLogging()
                .Options;

            // When
            using (var context = new CustomContext(options))
            {
                var repository = new AircraftRepository(context);
                var uow = new UnitOfWork(context);

                repository.Add(_aircraft);
                uow.Save();
            }

            // Then
            using (var context = new CustomContext(options))
            {
                var repository = new AircraftRepository(context);

                var result = repository.GetAll().Single(x => x.ModelName == _aircraft.ModelName);

                Assert.NotNull(result);
            }
        }
    }
}
