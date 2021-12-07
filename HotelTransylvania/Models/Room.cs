using HotelTransylvania.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
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
        public RoomProperties RoomProperties { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        [Required]
        [Precision(6, 2)]
        [DataType(DataType.Currency)]
        public decimal PricePerNight { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public bool IsRoomAvaiableByDateRange(DateTimeRange bookingRange) => !Bookings.Any(b => bookingRange.Intersects(new DateTimeRange(b.From, b.To)));

        public override string ToString()
        {
            return $"Room number: {RoomNumber} - Type: {RoomType.Type} - Size: {RoomProperties?.RoomSize.ToString("{0:00.00}")} - Price per night: {PricePerNight} - Room status: {IsRoomActive}";
        }

        private string IsRoomActive => IsActive ? "Active" : "Not Active";
    }
}
