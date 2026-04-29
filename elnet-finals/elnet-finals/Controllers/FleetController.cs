using elnet_finals.Models;
using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class FleetController : Controller
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
    {
        new Vehicle {
            Id = 1,
            Name = "Executive Coach Pro",
            Capacity = 45,
            PricePerHour = 320,
            ImageUrl = "/images/bus1.jpg",
            Description = "Luxury coach with premium seating"
        },
        new Vehicle {
            Id = 2,
            Name = "Elite Sprinter Van",
            Capacity = 12,
            PricePerHour = 210,
            ImageUrl = "/images/van1.jpg",
            Description = "Compact luxury van"
        }
    };

        public IActionResult Index()
        {
            return View(vehicles);
        }

        public IActionResult Details(int id)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            return View(vehicle);
        }
    }
}
