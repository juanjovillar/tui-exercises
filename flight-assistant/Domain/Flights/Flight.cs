using Domain.Aircrafts;
using Domain.Airports;
using Domain.Common;

namespace Domain.Flights
{
    public class Flight : IEntity
    {
        public Flight(
            Airport departureAirport,
            Airport destinationAirport,
            Aircraft aircraft)
        {
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            Aircraft = aircraft;
        }

        public int Id { get; set; }

        public Airport DepartureAirport { get; set; }

        public Airport DestinationAirport { get; set; }

        public Aircraft Aircraft { get; set; }

        public double Distance => DepartureAirport.GeoPosition.GetDistanceTo(DestinationAirport.GeoPosition);

        public double RequiredFuel => Aircraft.ConsumptionOnTakeOff + Aircraft.ConsumptionPerKm * Distance / 1000;
    }
}
