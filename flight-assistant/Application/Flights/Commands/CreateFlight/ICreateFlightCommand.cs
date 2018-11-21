namespace Application.Flights.Commands.CreateFlight
{
    public interface ICreateFlightCommand
    {
        void Execute(CreateFlightModel model);
    }
}
