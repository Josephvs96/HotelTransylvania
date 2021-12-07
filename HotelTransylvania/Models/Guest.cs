using HotelTransylvania.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = null;

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; } = null;

        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; }

        public bool HasActiveBookings() => Bookings.Where(b => !b.IsBookingCheckedOut()).Any();

        public override string ToString()
        {
            return $"Guest Id: {Id} - Name: {Name} - Email: {Email.StringHasValue("No email entered")} - Phone: {PhoneNumber.StringHasValue("No phone number entered")} - Number of active bookings: {Bookings?.Count(x => !x.IsBookingCheckedOut()) ?? 0}";
        }
    }
}
