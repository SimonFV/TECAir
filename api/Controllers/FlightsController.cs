using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using api.Dtos.Requests;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FlightsController : ControllerBase
    {
        private readonly TecAirDBContext _context;

        public FlightsController(TecAirDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("flightsDeals")]
        public async Task<IActionResult> flightsDeals()
        {
            if (ModelState.IsValid)
            {
                var flights = await DAL.Get_flights_deals();
                return Ok(flights);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("flightsByRoute")]
        public async Task<IActionResult> flightsByRoute(RouteReq route)
        {
            if (ModelState.IsValid)
            {
                var flights = await DAL.Get_flight_by_rute(route.Departure, route.Arrival);
                return Ok(flights);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("addFlight")]
        public async Task<IActionResult> AddFlight(FlightDto flight)
        {
            if (ModelState.IsValid)
            {
                var result = await DAL.Insert_flight(flight.PlaneId, flight.Departure,
                                    flight.Arrival, flight.Gate,
                                    flight.Schedule.ToString("yyyy-MM-dd HH:mm:ss"),
                                    flight.Deals);
                if (result)
                {
                    return Ok();
                }
                return new JsonResult("Problem while creating the flight.") { StatusCode = 500 };
            }

            return new JsonResult("Invalid model for flight.") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("addRoute")]
        public async Task<IActionResult> AddRoute(RouteDto route)
        {
            if (ModelState.IsValid)
            {
                var result = await DAL.Insert_rute(route.Departure, route.Scale,
                                    route.Arrival, route.Miles);
                if (result)
                {
                    return Ok();
                }
                return new JsonResult("Problem while creating the route.") { StatusCode = 500 };
            }

            return new JsonResult("Invalid model for route.") { StatusCode = 500 };
        }

        [HttpPost]
        [Route("addPlane")]
        public async Task<IActionResult> AddPlane(PlaneDto plane)
        {
            if (ModelState.IsValid)
            {
                var result = await DAL.Insert_plane(plane.AirplaneLicense, plane.Capacity,
                                    plane.Model);
                if (result)
                {
                    return Ok();
                }
                return new JsonResult("Problem while creating the plane.") { StatusCode = 500 };
            }

            return new JsonResult("Invalid model for plane.") { StatusCode = 500 };
        }

        [HttpPut]
        [Route("updateDeal")]
        public async Task<IActionResult> addDeal(DealDto deal)
        {
            if (ModelState.IsValid)
            {
                var result = await DAL.Update_flight_deal(deal.IdFlight, deal.Deal);
                if (result)
                {
                    return Ok();
                }
                return new JsonResult("Problem while updating the deal.") { StatusCode = 500 };
            }

            return new JsonResult("Invalid model for deal.") { StatusCode = 500 };
        }

    }
}

