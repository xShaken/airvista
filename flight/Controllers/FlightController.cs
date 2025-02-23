using flight.Data;
using flight.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace flight.Controllers
{
    public class FlightController : Controller
    {
        private readonly AppDbContext _context;

        public FlightController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var airlines = _context.Airlines.ToList();
            var airports = _context.Airports.ToList();

            ViewBag.Airlines = airlines;
            ViewBag.Airports = airports;

            var flights = _context.Flights
                .Include(f => f.Airline)
                .Include(f => f.FromAirport)
                .Include(f => f.ToAirport)
                .OrderByDescending(f => f.DateAdded)
                .AsNoTracking()
                .ToList();

            return View("~/Views/Home/Flights.cshtml", flights);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightCode, AirlineId, AircraftCode, FromAirportId, ToAirportId, DepartureDateTime, EstimatedArrivalDateTime, BusinessClassSeats, BusinessClassPrice, EconomyClassSeats, EconomyClassPrice, FirstClassSeats, FirstClassPrice")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                flight.DateAdded = DateTime.Now;
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();
                Console.WriteLine("Flight saved successfully.");
                return RedirectToAction("Index"); // Redirect after saving
            }

            Console.WriteLine("ModelState is invalid:");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }

            // Reload dropdown lists to avoid errors
            ViewBag.Airlines = _context.Airlines.ToList();
            ViewBag.Airports = _context.Airports.ToList();

            var flights = _context.Flights
                .Include(f => f.Airline)
                .Include(f => f.FromAirport)
                .Include(f => f.ToAirport)
                .OrderByDescending(f => f.DateAdded)
                .AsNoTracking()
                .ToList();

            return View("~/Views/Home/Flights.cshtml", flights);
        }


    }
}
