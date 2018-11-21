using Application.Interfaces;
using Domain.Aircrafts;
using Infrastructure.Common;

namespace Infrastructure.Aircrafts
{
    public class AircraftRepository : Repository<Aircraft>, IAircraftRepository
    {
        public AircraftRepository(CustomContext context) : base(context)
        {
        }
    }
}
