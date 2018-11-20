using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;

namespace Application.Airports.Queries.GetAirportsList
{
    public class GetAirportsListQuery : IGetAirportsListQuery
    {
        private readonly IAirportRepository _repository;

        public GetAirportsListQuery(IAirportRepository repository)
        {
            _repository = repository;
        }

        public List<AirportListItemReadModel> Execute()
        {
            var flights = _repository.GetAll()
                .Select(a => new AirportListItemReadModel
                {
                    Id = a.Id,
                    IATA = a.IATA,
                    City = a.City,
                });

            return flights.ToList();
        }
    }
}
