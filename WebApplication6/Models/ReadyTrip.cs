using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class ReadyTrip
    {
        [Key]
        public int TripID { get; set; }
        public string TripName { get; set; }
        public string TripDescription { get; set; }
        public string TripRoute { get; set; }
        public string Category { get; set; }
    }
}
