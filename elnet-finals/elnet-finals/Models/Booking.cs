using System.ComponentModel.DataAnnotations;

namespace elnet_finals.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pickup location is required")]
        public string PickupLocation { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; }

        public DateTime TripDate { get; set; }

        [Range(1, 10, ErrorMessage = "Adults must be between 1 and 10")]
        public int Adults { get; set; }

        public int Children { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public int VehicleId { get; set; }
    }
}
