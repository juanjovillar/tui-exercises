using Application.Interfaces;

namespace Application.Flights.Queries.GetFlightDetail
{
    public class GetFlightDetailQuery : IGetFlightDetailQuery
    {
        private readonly IFlightRepository _repository;

        public GetFlightDetailQuery(IFlightRepository repository)
        {
            _repository = repository;
        }

        public FlightDetailReadModel Execute(int flightId)
        {
            var flight = _repository.Get(flightId);

            return new FlightDetailReadModel
            {
                Id = flight.Id,
                AircraftId = flight.AircraftId,
                DepartureAirportId = flight.DepartureAirportId,
                DestinationAirportId = flight.DestinationAirportId,
                DepartureAirportName = flight.DepartureAirport.IATA,
                DestinationAirportName = flight.DestinationAirport.IATA,
                AircraftModel = flight.Aircraft.ModelName,
                Distance = flight.Distance,
                RequiredFuel = flight.RequiredFuel
            };
        }
    }
}
