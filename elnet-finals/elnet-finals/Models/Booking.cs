namespace elnet_finals.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        BankTransfer
    }

    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }

    public class Booking
    {
        public int Id { get; set; }

        // Foreign keys
        public int BusId { get; set; }
        // Compatibility with existing view
        public int VehicleId { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        // TripDate is an alias for StartDate for legacy view compatibility
        [DataType(DataType.Date)]
        public DateTime TripDate { get; set; }


        // Navigation properties
        public Vehicle Bus { get; set; }
        public ApplicationUser User { get; set; }

        // Rental period
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        // Extras
        public bool WiFi { get; set; }
        public bool Insurance { get; set; }
        public bool ExtraLuggage { get; set; }

        // Pricing
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        // Payment
        public PaymentMethod PaymentMethod { get; set; }

        // Status
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
    }
}
