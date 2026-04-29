namespace elnet_finals.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
