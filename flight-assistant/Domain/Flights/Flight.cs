using Domain.Aircrafts;
using Domain.Airports;
using Domain.Common;
using GeoCoordinatePortable;

namespace Domain.Flights
{
    public class Flight : IEntity
    {
        protected Flight()
        {
        }

        public Flight(Airport departureAirport, Airport destinationAirport, Aircraft aircraft)
        {
            DestinationAirport = destinationAirport;
            DestinationAirportId = destinationAirport.Id;
            DepartureAirport = departureAirport;
            DestinationAirportId = departureAirport.Id;
            Aircraft = aircraft;
            AircraftId = aircraft.Id;
        }

        public int Id { get; set; }

        public int DepartureAirportId { get; set; }

        public int DestinationAirportId { get; set; }

        public int AircraftId { get; set; }

        public virtual Airport DepartureAirport { get; set; }

        public virtual Airport DestinationAirport { get; set; }

        public virtual Aircraft Aircraft { get; set; }

        public double Distance
        {
            get
            {
                var depGeo = new GeoCoordinate(DepartureAirport.Latitude, DepartureAirport.Longitude);
                var destGeo = new GeoCoordinate(DestinationAirport.Latitude, DestinationAirport.Longitude);
                return depGeo.GetDistanceTo(destGeo);
            }
        }

        public double RequiredFuel => Aircraft.ConsumptionOnTakeOff + Aircraft.ConsumptionPerKm * Distance / 1000;
    }
}
