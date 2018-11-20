using Application.Flights.Queries.GetFlightsList;
using Application.Interfaces;
using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using GeoCoordinatePortable;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.UnitTest.Flights.Queries
{
    public class GetFlightsList
    {
        private readonly GetFlightsListQuery _query;
        private readonly Mock<IFlightRepository> _repository;
        private readonly Airport _departureAirpot;
        private readonly Airport _destinationAirport;
        private readonly Aircraft _aircraft;

        public GetFlightsList()
        {
            _departureAirpot = new Airport
            {
                IATA = "BIO",
                City = "Bilbao",
                GeoPosition = new GeoCoordinate(43.30110168457031, 2.9106099605560303)
            };

            _destinationAirport = new Airport
            {
                IATA = "AGP",
                City = "Malaga",
                GeoPosition = new GeoCoordinate(36.67490005493164, 4.499110221862793)
            };

            _aircraft = new Aircraft
            {
                ModelName = "Airbus A320",
                ConsumptionPerKm = 100,
                ConsumptionOnTakeOff = 20
            };

            var flightList = new List<Flight>
            {
                new Flight(_departureAirpot, _destinationAirport, _aircraft)
            };

            _repository = new Mock<IFlightRepository>();
            _repository.Setup(x => x.GetAll()).Returns(flightList.AsQueryable);

            _query = new GetFlightsListQuery(_repository.Object);
        }

        [Fact]
        public void Should_Return_List_Of_Flight_Read_Models()
        {
            //Given

            //When
            var results = _query.Execute();

            var result = results.Single();

            //Then
            Assert.IsType<List<FlightListItemReadModel>>(results);

            Assert.Equal(result.DepartureAirportName, _departureAirpot.IATA);
            Assert.Equal(result.DestinationAirportName, _destinationAirport.IATA);
            Assert.Equal(result.AircraftModel, _aircraft.ModelName);
        }
    }
}
