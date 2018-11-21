using Application.Flights.Commands.CreateFlight;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Presentation.Flights.Models
{
    public class UpsertFlightViewModel
    {
        public List<SelectListItem> Airports { get; set; }

        public List<SelectListItem> Aircrafts { get; set; }

        public CreateFlightModel Flight { get; set; }
    }
}
