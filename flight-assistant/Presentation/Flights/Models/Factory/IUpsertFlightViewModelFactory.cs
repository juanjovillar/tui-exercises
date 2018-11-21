namespace Presentation.Flights.Models.Factory
{
    public interface IUpsertFlightViewModelFactory
    {
        UpsertFlightViewModel Create();

        UpsertFlightViewModel Create(int flightId);
    }
}