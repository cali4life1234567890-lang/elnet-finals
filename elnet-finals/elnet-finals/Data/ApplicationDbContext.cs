using Microsoft.EntityFrameworkCore;
using elnet_finals.Models;

namespace elnet_finals.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
