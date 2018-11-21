using Application.Flights.Commands.CreateFlight;

namespace Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightModel
    {
        public int FlightId { get; set; }

        public CreateFlightModel Flight { get; set; }
    }
}
