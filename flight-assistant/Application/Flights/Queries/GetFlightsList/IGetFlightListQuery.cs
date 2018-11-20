using System.Collections.Generic;

namespace Application.Flights.Queries.GetFlightsList
{
    public interface IGetFlightListQuery
    {
        List<FlightListItemReadModel> Execute();
    }
}
