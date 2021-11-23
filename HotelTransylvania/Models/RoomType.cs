using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Type { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
