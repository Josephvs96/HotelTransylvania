using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelTransylvania.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Guests")]
        public Guest Guest { get; set; }

        [Required]
        [Precision(10, 2)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PayedAtUTC { get; set; }
    }
}