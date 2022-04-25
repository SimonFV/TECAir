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
    /* 
    Reservations Controller
    Controller responsible for the management of the reservations information.
    */
    [ApiController]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReservationsController : ControllerBase
    {
        private readonly TecAirDBContext _context;

        public ReservationsController(TecAirDBContext context)
        {
            _context = context;
        }

        /* 
        Get Seats Flight
        POST for retreiving all the seats taken in a flight.
        @param:
            int: id of the flight
        @return:
            List of the seats in the flight.
        */
        [HttpPost]
        [Route("getSeatsFlight/{id}")]
        public async Task<IActionResult> GetSeatsFlight(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await DAL.get_seats_flight(id);
                    return Ok(result);
                }
                catch
                {
                    return new JsonResult("Problem while retrieving the seats.") { StatusCode = 500 };
                }
            }

            return new JsonResult("Invalid value for id.") { StatusCode = 500 };
        }

        /* 
        Reserve Flight
        POST for making a reservation for a flight.
        @param:
            BookDto: DTO with the user and flight information.
        @return:
            Result of the operation
        */
        [HttpPost]
        [Route("reserveFlight")]
        public async Task<IActionResult> ReserveFlight(BookDto book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await DAL.Insert_book(book.Email, book.IdFlight, book.Status);
                    if (result)
                    {
                        return Ok();
                    }
                    return new JsonResult("Problem while adding the book.") { StatusCode = 500 };
                }
                catch
                {
                    return new JsonResult("Problem while adding the book.") { StatusCode = 500 };
                }
            }

            return new JsonResult("Invalid model for book.") { StatusCode = 500 };
        }

        /* 
        Checkin
        POST for making a checkin for a user.
        @param:
            BookDto: DTO with the user and flight information.
        @return:
            Result of the operation
        */
        [HttpPut]
        [Route("checkin")]
        public async Task<IActionResult> Checkin(BookDto book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await DAL.Update_book(book.Email, book.IdFlight, book.Seat, book.Status);
                    if (result)
                    {
                        return Ok();
                    }
                    return new JsonResult("Problem while checkin the user.") { StatusCode = 500 };
                }
                catch
                {
                    return new JsonResult("Problem while checkin the user.") { StatusCode = 500 };
                }
            }

            return new JsonResult("Invalid model for book.") { StatusCode = 500 };
        }

        /* 
        Add Baggage
        POST for adding baggage for a user.
        @param:
            BaggageDto: DTO with the user and bag information.
        @return:
            Result of the operation
        */
        [HttpPost]
        [Route("addBaggage")]
        public async Task<IActionResult> AddBaggage(BaggageDto bag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await DAL.Insert_baggage(bag.Email, bag.Weight, bag.Color);
                    if (result)
                    {
                        return Ok();
                    }
                    return new JsonResult("Problem while adding the baggage.") { StatusCode = 500 };
                }
                catch
                {
                    return new JsonResult("Problem while adding the baggage.") { StatusCode = 500 };
                }
            }

            return new JsonResult("Invalid model for baggage.") { StatusCode = 500 };
        }

    }
}

