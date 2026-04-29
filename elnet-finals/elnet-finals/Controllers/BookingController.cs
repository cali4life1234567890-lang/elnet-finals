using elnet_finals.Models;
using Microsoft.AspNetCore.Mvc;

namespace elnet_finals.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Create(int vehicleId)
        {
            ViewBag.VehicleId = vehicleId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Save to DB later
                return RedirectToAction("Index", "Home");
            }

            return View(booking);
        }
    }
}

