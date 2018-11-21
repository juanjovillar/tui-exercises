namespace Application.Flights.Queries.GetFlightDetail
{
    public class FlightDetailReadModel
    {
        public int Id { get; set; }

        public int DepartureAirportId { get; set; }

        public int DestinationAirportId { get; set; }

        public int AircraftId { get; set; }

        public string DepartureAirportName { get; set; }

        public string DestinationAirportName { get; set; }

        public string AircraftModel { get; set; }

        public double Distance { get; set; }

        public double RequiredFuel { get; set; }
    }
}
