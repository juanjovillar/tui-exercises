using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Flights.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }

        public string SourceAirport { get; set; }

        public string DestinationAirport { get; set; }
    }
}
