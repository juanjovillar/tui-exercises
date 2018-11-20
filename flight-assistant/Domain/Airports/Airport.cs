using GeoCoordinatePortable;

namespace Domain.Airports
{
    public class Airport
    {
        public string IATA { get; set; }

        public string City { get; set; }

        public GeoCoordinate GeoPosition { get; set; }
    }
}