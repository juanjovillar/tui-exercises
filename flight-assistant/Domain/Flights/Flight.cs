﻿using System;
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
            DepartureAirportId = departureAirport.Id;
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
                var distance = depGeo.GetDistanceTo(destGeo) / 1000;
                return Math.Round(distance, 2) ;
            }
        }

        public double RequiredFuel => Math.Round(Aircraft.ConsumptionOnTakeOff + Aircraft.ConsumptionPerKm * Distance, 2);
    }
}
