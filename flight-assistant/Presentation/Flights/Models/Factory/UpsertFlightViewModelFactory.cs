using Application.Aircrafts.Queries.GetAircraftList;
using Application.Airports.Queries.GetAirportsList;
using Application.Flights.Commands.CreateFlight;
using Application.Flights.Queries.GetFlightDetail;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Presentation.Flights.Models.Factory
{
    public class UpsertFlightViewModelFactory : IUpsertFlightViewModelFactory
    {
        private readonly IGetAirportsListQuery _airportsListQuery;
        private readonly IGetAircraftListQuery _aircraftListQuery;
        private readonly IGetFlightDetailQuery _flightQuery;

        public UpsertFlightViewModelFactory(
            IGetAirportsListQuery airportsListQuery,
            IGetAircraftListQuery aircraftListQuery,
            IGetFlightDetailQuery flightQuery)
        {
            _airportsListQuery = airportsListQuery;
            _aircraftListQuery = aircraftListQuery;
            _flightQuery = flightQuery;
        }

        public UpsertFlightViewModel Create()
        {
            var airports = _airportsListQuery.Execute();
            var aircrafts = _aircraftListQuery.Execute();

            var viewModel = new UpsertFlightViewModel();

            viewModel.Airports = airports
                .Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.IATA} - {a.City}",
                })
                .ToList();

            viewModel.Aircrafts = aircrafts
                .Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.ModelName,
                })
                .ToList();

            viewModel.Flight = new CreateFlightModel();

            return viewModel;
        }

        public UpsertFlightViewModel Create(int flightId)
        {
            var airports = _airportsListQuery.Execute();
            var aircrafts = _aircraftListQuery.Execute();
            var flight = _flightQuery.Execute(flightId);

            var viewModel = new UpsertFlightViewModel();

            viewModel.Airports = airports
                .Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.IATA} - {a.City}",
                })
                .ToList();

            viewModel.Aircrafts = aircrafts
                .Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.ModelName,
                })
                .ToList();

            viewModel.Flight = new CreateFlightModel()
            {
                DepartureAirportId = flight.DepartureAirportId,
                DestinationAirportId = flight.DestinationAirportId,
                AircraftId = flight.AircraftId
            };

            return viewModel;
        }

    }
}
