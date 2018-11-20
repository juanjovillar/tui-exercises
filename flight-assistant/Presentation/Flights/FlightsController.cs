using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Flights.Models;
using System.Collections.Generic;

namespace Presentation.Flights
{
    public class FlightsController : Controller
    {
        // GET: Flights
        public ActionResult Index()
        {
            var flights = new List<FlightViewModel>
            {
                new FlightViewModel
                {
                    Id = 1,
                    SourceAirport = "SARP",
                    DestinationAirport = "DARP"
                },
                new FlightViewModel
                {
                    Id = 2,
                    SourceAirport = "SARP",
                    DestinationAirport = "DARP"
                },
            };

            return View(flights);
        }

        // GET: Flights/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Flights/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flights/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}