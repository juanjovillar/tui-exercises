namespace Application.Flights.Commands.UpdateFlight
{
    public interface IUpdateFlightCommand
    {
        void Execute(UpdateFlightModel model);
    }
}