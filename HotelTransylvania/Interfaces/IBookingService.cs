using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IBookingService
    {
        public Booking GetBookingById(int id);
        public IEnumerable<Booking> GetBookingsByGuestId(int id);
        public IEnumerable<Booking> GetOldDueBookings();
        public void AddNewBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void RemoveBooking(Booking booking);
        public Task RemoveBookingAsync(Booking booking);
        public void CheckAndCleanDueBooings();
    }
}
