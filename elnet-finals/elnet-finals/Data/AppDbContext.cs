using elnet_finals.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace elnet_finals.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed sample buses (using Vehicle entity as bus)
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Name = "City Express", Type = "Mini Bus", Capacity = 12, PricePerHour = 15.00m, ImageUrl = "https://picsum.photos/seed/bus1/400/250", Description = "Comfortable mini‑bus for city travel" },
                new Vehicle { Id = 2, Name = "Interstate Coach", Type = "Coach", Capacity = 45, PricePerHour = 30.00m, ImageUrl = "https://picsum.photos/seed/bus2/400/250", Description = "Spacious coach for long distance" },
                new Vehicle { Id = 3, Name = "Luxury Van", Type = "Van", Capacity = 8, PricePerHour = 45.00m, ImageUrl = "https://picsum.photos/seed/bus3/400/250", Description = "Premium van with extra luggage space" }
            );
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}