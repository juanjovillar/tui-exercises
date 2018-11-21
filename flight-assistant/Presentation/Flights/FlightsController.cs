using Application.Flights.Commands.CreateFlight;
using Application.Flights.Commands.UpdateFlight;
using Application.Flights.Queries.GetFlightDetail;
using Application.Flights.Queries.GetFlightsList;
using Microsoft.AspNetCore.Mvc;
using Presentation.Flights.Models;
using Presentation.Flights.Models.Factory;
using System;

namespace Presentation.Flights
{
    public class FlightsController : Controller
    {
        private readonly IGetFlightListQuery _flightListQuery;
        private readonly IGetFlightDetailQuery _flightDetailQuery;
        private readonly IUpsertFlightViewModelFactory _upsertFlightViewModelFactory;
        private readonly ICreateFlightCommand _createFlightCommand;
        private readonly IUpdateFlightCommand _updateFlightCommand;

        public FlightsController(
            IGetFlightListQuery flightListQuery,
            IGetFlightDetailQuery flightDetailQuery,
            IUpsertFlightViewModelFactory upsertFlightViewModelFactory,
            ICreateFlightCommand createFlightCommand,
            IUpdateFlightCommand updateFlightCommand)
        {
            _flightListQuery = flightListQuery;
            _flightDetailQuery = flightDetailQuery;
            _upsertFlightViewModelFactory = upsertFlightViewModelFactory;
            _createFlightCommand = createFlightCommand;
            _updateFlightCommand = updateFlightCommand;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var flights = _flightListQuery.Execute();
            return View(flights);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var flight = _flightDetailQuery.Execute(id);
            return View(flight);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = _upsertFlightViewModelFactory.Create();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UpsertFlightViewModel viewModel)
        {
            try
            {
                _createFlightCommand.Execute(viewModel.Flight);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = _upsertFlightViewModelFactory.Create(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, UpsertFlightViewModel viewModel)
        {
            try
            {
                var updateModel = new UpdateFlightModel
                {
                    FlightId = id,
                    Flight = viewModel.Flight
                };

                _updateFlightCommand.Execute(updateModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}