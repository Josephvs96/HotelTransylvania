using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class Room
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public ExtraBeds ExtraBeds { get; set; }

        public RoomProperties RoomProperties { get; set; }

        [Required]
        public bool IsAvailble { get; set; }

        [Required]
        [Precision(2)]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }
    }
}
