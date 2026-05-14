using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text.Json;
using elnet_finals.Data;
using elnet_finals.Models;
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



    // GET: /Booking/Step1
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


    // POST: Show additional details form after step1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Details(BookingStep1ViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Step1", model);
        }
        // Map step1 data to the detailed view model
        var detailsModel = new BookingDetailsViewModel
        {
            VehicleId = model.VehicleId,
            VehicleName = model.VehicleName,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            // Additional fields left for user input
        };
        return View("Details", detailsModel);
    }

    // POST action to finalize booking after collecting details
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Confirm(BookingDetailsViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Return to details view if validation fails
            return View("Details", model);
        }

        // Check availability
        var isAvailable = await _availabilityService.IsBusAvailableAsync(model.VehicleId, model.StartDate, model.EndDate);
        if (!isAvailable)
        {
            ModelState.AddModelError(string.Empty, "Selected vehicle is not available for the chosen dates.");
            return View("Details", model);
        }

        var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
        if (vehicle == null) return NotFound();

        var totalHours = (model.EndDate - model.StartDate).TotalHours;
        var totalPrice = vehicle.PricePerHour * (decimal)totalHours;

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        var booking = new Booking
        {
            BusId = model.VehicleId,
            UserId = userId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            TotalPrice = totalPrice,
            Status = BookingStatus.Pending,
            PickupLocation = model.PickupLocation,
            Destination = model.Destination,
            WiFi = model.WiFi,
            Insurance = model.Insurance,
            ExtraLuggage = model.ExtraLuggage
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToAction("MyBookings");
    }
    // GET: /Booking/MyBookings
    public async Task<IActionResult> MyBookings()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        var bookings = await _context.Bookings
            .Include(b => b.Bus)
            .Where(b => b.UserId == userId)
            .ToListAsync();
        return View(bookings);
    }

    // POST: /Booking/Cancel
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        if (booking == null)
        {
            return NotFound();
        }

        // Set status to Cancelled rather than deleting row
        booking.Status = BookingStatus.Cancelled;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(MyBookings));
    }

}