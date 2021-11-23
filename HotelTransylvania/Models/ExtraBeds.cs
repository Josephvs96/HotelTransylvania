using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class ExtraBeds
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool HasExtraBeds { get; set; }

        [Required]
        public int NumberOfExtraBeds { get; set; }
    }
}
