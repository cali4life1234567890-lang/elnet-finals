using elnet_finals.Data;
using elnet_finals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class BookingController : Controller
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create(int vehicleId)
    {
        ViewBag.VehicleId = vehicleId;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Bookings.Add(booking);

            _context.SaveChanges();

            return RedirectToAction("MyBookings");
        }

        return View(booking);
    }

    public IActionResult MyBookings()
    {
        var bookings = _context.Bookings.ToList();

        return View(bookings);
    }
}