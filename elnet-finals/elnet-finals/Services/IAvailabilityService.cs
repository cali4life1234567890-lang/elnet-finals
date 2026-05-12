using System;
using System.Threading.Tasks;

namespace elnet_finals.Services
{
    public interface IAvailabilityService
    {
        /// <summary>
        /// Returns true if the specified bus is available for the entire period.
        /// </summary>
        /// <param name="busId">Id of the bus (Vehicle) to check.</param>
        /// <param name="start">Start date/time of the desired rental.</param>
        /// <param name="end">End date/time of the desired rental.</param>
        /// <returns>True when no overlapping bookings exist.</returns>
        Task<bool> IsBusAvailableAsync(int busId, DateTime start, DateTime end);
    }
}
