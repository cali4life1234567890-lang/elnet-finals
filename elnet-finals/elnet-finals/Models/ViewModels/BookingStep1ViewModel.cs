namespace elnet_finals.Models.ViewModels
{
    public class BookingStep1ViewModel
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool WiFi { get; set; }
        public bool Insurance { get; set; }
        public bool ExtraLuggage { get; set; }
    }
}
