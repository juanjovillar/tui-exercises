using Application.Flights.Commands.CreateFlight;
using Application.Flights.Commands.Services;
using Application.Interfaces;
using Domain.Aircrafts;
using Domain.Airports;
using Domain.Flights;
using Moq;
using Xunit;

namespace Application.UnitTest.Flights.Commands
{
    public class CreateFlightCommandTests
    {
        private readonly CreateFlightCommand _command;
        private readonly Mock<IFlightRepositoryFacade> _repositories;
        private readonly Mock<IUnitOfWork> _uow;

        public CreateFlightCommandTests()
        {
            _repositories = new Mock<IFlightRepositoryFacade>();
            _repositories.Setup(x => x.GetAirport(It.IsAny<int>())).Returns(new Airport());
            _repositories.Setup(x => x.GetAircraft(It.IsAny<int>())).Returns(new Aircraft());

            _uow = new Mock<IUnitOfWork>();

            _command = new CreateFlightCommand(_repositories.Object, _uow.Object);
        }

        [Fact]
        public void Command_Should_Add_New_Flight_To_Repository()
        {
            //Given 
            var model = new CreateFlightModel
            {
                DestinationAirportId = 1,
                DepartureAirportId = 1,
                AircraftId = 1
            };

            //When 
            _command.Execute(model);

            //Then
            _repositories.Verify(x => x.AddFlight(It.IsAny<Flight>()), Times.Once);
        }

        [Fact]
        public void Command_Should_Persist_Changes()
        {
            //Given 
            var model = new CreateFlightModel
            {
                DestinationAirportId = 1,
                DepartureAirportId = 1,
                AircraftId = 1
            };

            //When 
            _command.Execute(model);

            //Then
            _uow.Verify(x => x.Save(), Times.Once);
        }
    }
}
