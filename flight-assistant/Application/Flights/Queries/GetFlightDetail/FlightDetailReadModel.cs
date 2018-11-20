namespace Application.Flights.Queries.GetFlightDetail
{
    public class FlightDetailReadModel
    {
        public int Id { get; set; }

        public string DepartureAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string AircraftModel { get; set; }

        public double Distance { get; set; }

        public double RequiredFuel { get; set; }
    }
}
