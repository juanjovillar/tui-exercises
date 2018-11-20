using System.Collections.Generic;
using Domain.Common;
using Domain.Flights;

namespace Domain.Aircrafts
{
    public class Aircraft : IEntity
    {
        public Aircraft()
        {
            Flights = new List<Flight>();
        }

        public int Id { get; set; }

        public string ModelName { get; set; }

        public double ConsumptionOnTakeOff { get; set; }

        public double ConsumptionPerKm { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}   