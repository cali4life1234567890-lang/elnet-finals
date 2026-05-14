namespace elnet_finals.Models.ViewModels
{
    public class BookingDetailsViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public bool WiFi { get; set; }
        public bool Insurance { get; set; }
        public bool ExtraLuggage { get; set; }
    }
}
