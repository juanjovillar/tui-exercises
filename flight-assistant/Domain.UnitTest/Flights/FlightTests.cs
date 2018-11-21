using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using Xunit;

namespace Domain.UnitTest.Flights
{
    public class FlightTests
    {
        private readonly Flight _sut;
        private readonly Airport _newAirport;
        private readonly Aircraft _aircraft;
        private readonly Aircraft _newAircraft;

        public FlightTests()
        {

            var departureAirport = new Airport
            {
                IATA = "BIO",
                City = "Bilbao",
                Latitude = 43.30110168457031,
                Longitude = 2.9106099605560303
            };

            var destinationAirport = new Airport
            {
                IATA = "AGP",
                City = "Malaga",
                Latitude = 36.67490005493164,
                Longitude = 4.499110221862793
            };

            _newAirport = new Airport
            {
                IATA = "JFK",
                City = "New York",
                Latitude = 40.63980103,
                Longitude = 73.77890015
            };

            _aircraft = new Aircraft
            {
                ModelName = "Airbus A320",
                ConsumptionPerKm = 100,
                ConsumptionOnTakeOff = 20
            };

            _newAircraft = new Aircraft
            {
                ModelName = "Airbus A300",
                ConsumptionPerKm = 150,
                ConsumptionOnTakeOff = 35
            };

            _sut = new Flight(departureAirport, destinationAirport, _aircraft);
        }

        [Fact]
        public void RequiredFuel_Is_Properly_Calculated()
        {
            //Given
            var expectedFuel = _aircraft.ConsumptionOnTakeOff + _aircraft.ConsumptionPerKm * _sut.Distance / 1000;

            //When

            //Then
            Assert.Equal(expectedFuel, _sut.RequiredFuel);
        }

        [Fact]
        public void Distance_Is_Updated_When_DepartureAirport_Changes()
        {
            //Given
            var originalDistance = _sut.Distance;

            //When
            _sut.DepartureAirport = _newAirport;

            //Then
            Assert.NotEqual(_sut.Distance, originalDistance);
        }

        [Fact]
        public void Distance_Is_Updated_When_DestinationAirport_Changes()
        {
            //Given
            var originalDistance = _sut.Distance;

            //When
            _sut.DestinationAirport = _newAirport;

            //Then
            Assert.NotEqual(_sut.Distance, originalDistance);
        }

        [Fact]
        public void RequiredFuel_Is_Updated_When_DepartureAirport_Changes()
        {
            //Given
            var originalRequiredFuel = _sut.RequiredFuel;

            //When
            _sut.DepartureAirport = _newAirport;

            //Then
            Assert.NotEqual(_sut.RequiredFuel, originalRequiredFuel);
        }

        [Fact]
        public void RequiredFuel_Is_Updated_When_DestinationAirport_Changes()
        {
            //Given
            var originalRequiredFuel = _sut.RequiredFuel;

            //When
            _sut.DestinationAirport = _newAirport;

            //Then
            Assert.NotEqual(_sut.RequiredFuel, originalRequiredFuel);
        }

        [Fact]
        public void RequiredFuel_Is_Updated_When_Aircraft_Changes()
        {
            //Given
            var originalRequiredFuel = _sut.RequiredFuel;

            //When
            _sut.Aircraft = _newAircraft;

            //Then
            Assert.NotEqual(_sut.RequiredFuel, originalRequiredFuel);
        }

    }
}
