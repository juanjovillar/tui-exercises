using Application.Flights.Commands.CreateFlight.Repository;
using Application.Interfaces;
using Domain.Flights;

namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommand : ICreateFlightCommand
    {
        private readonly IFlightRepositoryFacade _repositories;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFlightCommand(
            IFlightRepositoryFacade repositories,
            IUnitOfWork unitOfWork)
        {
            _repositories = repositories;
            _unitOfWork = unitOfWork;
        }

        public void Execute(CreateFlightModel model)
        {
            var departureAirpot = _repositories.GetAirport(model.DepartureAirportId);

            var destinationAirpot = _repositories.GetAirport(model.DestinationAirportId);

            var aircraft = _repositories.GetAircraft(model.AircraftId);

            var flight = new Flight(departureAirpot, destinationAirpot, aircraft);

            _repositories.AddFlight(flight);

            _unitOfWork.Save();
        }
    }
}
