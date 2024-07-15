// Controllers/TripsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _context.ReadyTrips
                .OrderBy(t => t.Category)
                .ToListAsync();

            return Ok(trips);
        }
    }
}
