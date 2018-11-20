using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;

namespace Application.Aircrafts.Queries.GetAircraftList
{
    public class GetAircraftsListQuery : IGetAircraftListQuery
    {
        private readonly IAircraftRepository _repository;

        public GetAircraftsListQuery(IAircraftRepository repository)
        {
            _repository = repository;
        }

        public List<AircraftListItemReadModel> Execute()
        {
            var flights = _repository.GetAll()
                .Select(a => new AircraftListItemReadModel
                {
                    Id = a.Id,
                    ModelName = a.ModelName
                });

            return flights.ToList();
        }
    }
}
