using System.Collections.Generic;

namespace Application.Aircrafts.Queries.GetAircraftList
{
    public interface IGetAircraftListQuery
    {
        List<AircraftListItemReadModel> Execute();
    }
}
