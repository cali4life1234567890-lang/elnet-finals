namespace elnet_finals.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string PickupLocation { get; set; }
        public string Destination { get; set; }
        public DateTime TripDate { get; set; }

        public int Adults { get; set; }
        public int Children { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int VehicleId { get; set; }
    }
}
