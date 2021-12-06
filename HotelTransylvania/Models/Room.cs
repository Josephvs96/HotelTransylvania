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

        public bool IsRoomAvaiableByDate(DateTime bookingStart) => !Bookings.Any(b => new DateTimeRange(b.From, b.To).IsInRange(bookingStart));
        public bool IsRoomAvaiableByDateRange(DateTimeRange bookingRange) => !Bookings.Any(b => bookingRange.Intersects(new DateTimeRange(b.From, b.To)));
        public override string ToString()
        {
            return $"{IsRoomActive()} - Room number: {RoomNumber} - Type: {RoomType.Type} - Size: {RoomProperties?.RoomSize.ToString("{0:00.00}")} - Total number of beds: {CalculateNumberOfBeds()}";
        }

        private string IsRoomActive() => IsActive ? "Active" : "Not Active";

        private int CalculateNumberOfBeds()
        {
            switch (RoomType.Type)
            {
                case CustomTypes.RoomTypes.Single:
                    return 1;
                case CustomTypes.RoomTypes.Double:
                    return RoomProperties.ExtraBeds.NumberOfExtraBeds.HasValue ? 2 + RoomProperties.ExtraBeds.NumberOfExtraBeds.Value : 2;
                default: return 0;
            }
        }
    }
}
