namespace WebApplication6.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int BookingTypeID { get; set; }
        public int TripID { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime TripDate { get; set; }
        public int Passengers { get; set; }
        public DateTime StartOfService { get; set; }
        public DateTime EndOfService { get; set; }
        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public User User { get; set; }
        public BookingType BookingType { get; set; }
        public ReadyTrip ReadyTrip { get; set; }
    }
}
