using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;

namespace Application.Flights.Commands.Services
{
    public interface IFlightRepositoryFacade
    {
        Airport GetAirport(int airportId);

        Aircraft GetAircraft(int aircraftId);

        Flight GetFlight(int flightId);

        void AddFlight(Flight flight);
    }
}
