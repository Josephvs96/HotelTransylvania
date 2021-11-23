using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class RoomProperties
    {
        [Key]
        public int Id { get; set; }

        [Precision(2)]
        public decimal RoomSize { get; set; }

        public int NumberOfWindows { get; set; }
    }
}
