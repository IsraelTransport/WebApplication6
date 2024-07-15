using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class VehicleService
    {
        [Key]
        public int ServiceID { get; set; }
        public int VehicleID { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ServiceType { get; set; }
        public string ServiceDescription { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
