using Application.Interfaces;
using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;

namespace Application.Flights.Commands.CreateFlight.Repository
{
    public class FlightRepositoryFacade : IFlightRepositoryFacade
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAirportRepository _airportRespository;
        private readonly IAircraftRepository _aircraftRepository;

        public FlightRepositoryFacade(
            IFlightRepository flightRepository,
            IAirportRepository airportRespository,
            IAircraftRepository aircraftRepository)
        {
            _flightRepository = flightRepository;
            _airportRespository = airportRespository;
            _aircraftRepository = aircraftRepository;
        }

        public Airport GetAirport(int airportId)
        {
            return _airportRespository.Get(airportId);
        }

        public Aircraft GetAircraft(int aircraftId)
        {
            return _aircraftRepository.Get(aircraftId);
        }

        public void AddFlight(Flight flight)
        {
            _flightRepository.Add(flight);
        }
    }
}
