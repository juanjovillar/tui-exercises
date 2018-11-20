using Domain.Common;
using Domain.Flights;
using System.Collections.Generic;

namespace Domain.Airports
{
    public class Airport : IEntity
    {
        public Airport()
        {
            IncomingFlights = new List<Flight>();
            DepartingFlights = new List<Flight>();
        }

        public int Id { get; set; }

        public string IATA { get; set; }

        public string City { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Flight> IncomingFlights { get; set; }
        public virtual ICollection<Flight> DepartingFlights { get; set; }

        //public GeoCoordinate GeoPosition { get; set; }
    }
}