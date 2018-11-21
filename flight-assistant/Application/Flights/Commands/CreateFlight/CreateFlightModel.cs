namespace Application.Flights.Commands.CreateFlight
{
    public class CreateFlightModel
    {
        public int DestinationAirportId { get; set; }

        public int DepartureAirportId { get; set; }

        public int AircraftId { get; set; }
    }
}
