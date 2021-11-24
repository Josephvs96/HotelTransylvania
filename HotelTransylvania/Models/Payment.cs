using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public Guest Guest { get; set; }
        public decimal Amount { get; set; }
    }
}