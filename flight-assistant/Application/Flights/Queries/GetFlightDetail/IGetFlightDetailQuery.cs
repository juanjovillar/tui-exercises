namespace Application.Flights.Queries.GetFlightDetail
{
    public interface IGetFlightDetailQuery
    {
        FlightDetailReadModel Execute(int flightId);
    }
}
