using Application.Interfaces;
using Domain.Flights;
using Infrastructure.Common;

namespace Infrastructure.Flights
{
    public class FlightsRepository : Repository<Flight>, IFlightRepository
    {
        public FlightsRepository(CustomContext context) : base(context)
        {
        }
    }
}
