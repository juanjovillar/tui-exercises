using Application.Interfaces;
using Domain.Airports;
using Infrastructure.Common;

namespace Infrastructure.Airports
{
    public class AirportsRepository : Repository<Airport>, IAirportRepository
    {
        public AirportsRepository(CustomContext context) : base(context)
        {
        }
    }
}
