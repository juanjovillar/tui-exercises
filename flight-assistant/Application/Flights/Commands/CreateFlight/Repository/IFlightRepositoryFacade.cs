using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;

namespace Application.Flights.Commands.CreateFlight.Repository
{
    public interface IFlightRepositoryFacade
    {
        Airport GetAirport(int airportId);

        Aircraft GetAircraft(int aircraftId);

        void AddFlight(Flight flight);
    }
}
