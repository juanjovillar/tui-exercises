using Application.Airports.Queries.GetAirportsList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Airports
{
    public class AirportsController : Controller
    {
        private readonly IGetAirportsListQuery _airportsListQuery;

        public AirportsController(IGetAirportsListQuery airportsListQuery)
        {
            _airportsListQuery = airportsListQuery;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var airports = _airportsListQuery.Execute();

            return View(airports);
        }
    }
}