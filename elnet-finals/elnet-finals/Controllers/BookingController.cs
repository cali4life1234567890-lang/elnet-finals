using elnet_finals.Data;
using elnet_finals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using elnet_finals.Services;
using elnet_finals.Models.ViewModels;

[Authorize]
public class BookingController : Controller
{
    private readonly AppDbContext _context;

    private readonly IAvailabilityService _availabilityService;

    public BookingController(AppDbContext context, IAvailabilityService availabilityService)
    {
        _context = context;
        _availabilityService = availabilityService;
    }

    [HttpGet]
    public async Task<IActionResult> Step1(int vehicleId)
    {
        var vehicle = await _context.Vehicles.FindAsync(vehicleId);
        if (vehicle == null) return NotFound();

        var model = new BookingStep1ViewModel
        {
            VehicleId = vehicle.Id,
            VehicleName = vehicle.Name,
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(1)
        };
        return View(model);
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
            // Map VehicleId (legacy) to BusId (current model)
            if (booking.VehicleId != 0 && booking.BusId == 0)
            {
                booking.BusId = booking.VehicleId;
            }

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