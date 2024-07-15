using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication6.Data;
using WebApplication6.Models;
using System.Collections.Generic;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.BookingType)
                .Include(b => b.ReadyTrip)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            //if (booking == null)
            //{
            //    return BadRequest();
            //}

            // Attach existing entities without adding new ones
            _context.Attach(booking.User);
            _context.Attach(booking.BookingType);
            _context.Attach(booking.ReadyTrip);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingID }, booking);
        }

    }
}
