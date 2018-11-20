using Domain.Common;
using GeoCoordinatePortable;

namespace Domain.Airports
{
    public class Airport : IEntity
    {
        public int Id { get; set; }

        public string IATA { get; set; }

        public string City { get; set; }

        public GeoCoordinate GeoPosition { get; set; }
    }
}