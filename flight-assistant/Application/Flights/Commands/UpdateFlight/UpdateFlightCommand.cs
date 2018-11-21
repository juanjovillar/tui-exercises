using Application.Flights.Commands.Services;
using Application.Interfaces;

namespace Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IUpdateFlightCommand
    {
        private readonly IFlightRepositoryFacade _repositories;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFlightCommand(IFlightRepositoryFacade repositories, IUnitOfWork unitOfWork)
        {
            _repositories = repositories;
            _unitOfWork = unitOfWork;
        }

        public void Execute(UpdateFlightModel model)
        {
            var departureAirpot = _repositories.GetAirport(model.Flight.DepartureAirportId);
            var destinationAirpot = _repositories.GetAirport(model.Flight.DestinationAirportId);
            var aircraft = _repositories.GetAircraft(model.Flight.AircraftId);
            var flight = _repositories.GetFlight(model.FlightId);

            flight.DepartureAirport = departureAirpot;
            flight.DestinationAirport = destinationAirpot;
            flight.Aircraft = aircraft;

            _unitOfWork.Save();
        }
    }
}
