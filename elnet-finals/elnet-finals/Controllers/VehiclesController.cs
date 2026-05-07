using Microsoft.AspNetCore.Mvc;
using elnet_finals.Data;
using Microsoft.EntityFrameworkCore;

namespace elnet_finals.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            // This line gets all vehicles from the database
            var vehicles = await _context.Vehicles.ToListAsync();
            return View(vehicles);
        }
    }
}
