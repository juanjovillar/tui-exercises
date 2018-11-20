using System.Collections.Generic;

namespace Application.Airports.Queries.GetAirportsList
{
    public interface IGetAirportsListQuery
    {
        List<AirportListItemReadModel> Execute();
    }
}
