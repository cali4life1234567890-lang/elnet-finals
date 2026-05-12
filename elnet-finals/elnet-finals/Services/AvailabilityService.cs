using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using elnet_finals.Data;
using elnet_finals.Models;

namespace elnet_finals.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly AppDbContext _context;
        public AvailabilityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsBusAvailableAsync(int busId, DateTime start, DateTime end)
        {
            // Ensure start is before end
            if (start >= end) return false;

            // Look for any booking that overlaps the requested period
            var overlapping = await _context.Bookings.AnyAsync(b =>
                b.BusId == busId &&
                ((b.StartDate <= start && b.EndDate > start) ||
                 (b.StartDate < end && b.EndDate >= end) ||
                 (b.StartDate >= start && b.EndDate <= end)));


            return !overlapping;
        }

    }
}
