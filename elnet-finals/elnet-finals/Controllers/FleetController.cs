using elnet_finals.Data;
using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class FleetController : Controller
    {
        private readonly AppDbContext _context;

        public FleetController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();

            return View(vehicles);
        }

        public IActionResult Details(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == id);

            return View(vehicle);
        }
    }
}
