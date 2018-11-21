using Application.Aircrafts.Queries.GetAircraftList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Aircrafts
{
    public class AircraftsController : Controller
    {
        private readonly IGetAircraftListQuery _aircraftListQuery;

        public AircraftsController(IGetAircraftListQuery aircraftListQuery)
        {
            _aircraftListQuery = aircraftListQuery;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var aircrafts = _aircraftListQuery.Execute();

            return View(aircrafts);
        }
    }
}