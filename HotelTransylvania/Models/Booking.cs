using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Room Room { get; set; }

        [Required]
        public Guest Guest { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }

        [Precision(10, 2)]
        [DataType(DataType.Currency)]
        public decimal TotalCost { get; set; }

        [DefaultValue(false)]
        public bool IsPayed { get; set; } = false;

        public Payment Payment { get; set; }

        public bool IsBookingCheckedOut() => DateTime.UtcNow > To;

        public int BookingLength() => To.Subtract(From).Days;

        public bool IsPaymentDue() => DateTime.UtcNow.Subtract(From).Days > 10;

        public decimal CalculateTotalCost() => BookingLength() * Room.PricePerNight;

        public override string ToString()
        {
            return $"\nBooking number: {Id}\n" +
                $"Booked by: {Guest.Name}\n" +
                $"Booked from: {From.ToShortDateString()}\n" +
                $"Booked to: {To.ToShortDateString()}\n" +
                $"Payment status: {GetPaymentStatus()}\n" +
                $"Booked Room number: {Room.RoomNumber}\n";
        }

        private string GetPaymentStatus() => IsPayed ? "Payed" : "Not Payed";
    }
}