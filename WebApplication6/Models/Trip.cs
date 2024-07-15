namespace WebApplication6.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public string TripName { get; set; }
        public string TripDescription { get; set; }
        public string TripRoute { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
