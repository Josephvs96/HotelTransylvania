using HotelTransylvania.Enums;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public RoomTypes Type { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
