using Domain.Airports;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace Infrastructure.Airports
{
    public static class Airports
    {

        public static IEnumerable<Airport> Data => new List<Airport>
        {
            new Airport
            {
                IATA = "BIO",
                City = "Bilbao",
                GeoPosition = new GeoCoordinate(43.30110168457031, 2.9106099605560303)
            },
            new Airport
            {
                IATA = "AGP",
                City = "Malaga",
                GeoPosition = new GeoCoordinate(36.67490005493164, 4.499110221862793)
            },
            new Airport
            {
                IATA = "JFK",
                City = "New York",
                GeoPosition = new GeoCoordinate(40.63980103, 73.77890015)
            },
            new Airport
            {
                IATA = "CDG",
                City = "Paris",
                GeoPosition = new GeoCoordinate(49.0127983093, 2.54999995232)
            },
        };
    }
}
