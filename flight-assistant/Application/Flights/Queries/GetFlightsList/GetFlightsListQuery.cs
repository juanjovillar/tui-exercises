using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Flights.Queries.GetFlightsList
{
    public class GetFlightsListQuery : IGetFlightListQuery
    {
        private readonly IFlightRepository _repository;

        public GetFlightsListQuery(IFlightRepository repository)
        {
            _repository = repository;
        }

        public List<FlightListItemReadModel> Execute()
        {
            var flights = _repository
                .GetAll()
                .ToList()
                .Select(f => new FlightListItemReadModel
                {
                    Id = f.Id,
                    DepartureAirportName = f.DepartureAirport.IATA,
                    DestinationAirportName = f.DestinationAirport.IATA,
                    AircraftModel = f.Aircraft.ModelName,
                    Distance = f.Distance,
                    RequiredFuel = f.RequiredFuel
                });

            return flights.ToList();
        }
    }
}
