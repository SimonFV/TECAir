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
    public class ReservationsController : ControllerBase
    {
        private readonly TecAirDBContext _context;

        public ReservationsController(TecAirDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("getSeatsFlight/{id}")]
        public async Task<IActionResult> RetSeatsFlight(int id)
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

        /*

       [HttpPut("items/{id}")]
       public async Task<IActionResult> UpdateItem(int id, ItemData item)
       {
           if (id != item.Id)
               return BadRequest();

           var existItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

           if (existItem == null)
               return NotFound();

           existItem.Title = item.Title;
           existItem.Description = item.Description;
           existItem.Done = item.Done;
           await _context.SaveChangesAsync();

           return NoContent();
       }

       [HttpDelete("items/{id}")]
       public async Task<IActionResult> DeleteItem(int id)
       {
           var existItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

           if (existItem == null)
               return NotFound();

           _context.Items.Remove(existItem);
           await _context.SaveChangesAsync();

           return Ok(existItem);
       }
       */

    }
}

