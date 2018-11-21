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
                DepartureAirportName = $"{flight.DepartureAirport.IATA} - {flight.DepartureAirport.City}",
                DestinationAirportName = $"{flight.DestinationAirport.IATA} - {flight.DestinationAirport.City}",
                AircraftModel = flight.Aircraft.ModelName,
                Distance = flight.Distance,
                RequiredFuel = flight.RequiredFuel
            };
        }
    }
}
