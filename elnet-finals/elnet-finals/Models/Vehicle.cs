using System.ComponentModel.DataAnnotations;

namespace elnet_finals.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vehicle type is required")]
        public string Type { get; set; }

        public int Capacity { get; set; }

        [Range(0, 10000, ErrorMessage = "Price per hour must be between 0 and 10,000")]
        public decimal PricePerHour { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
