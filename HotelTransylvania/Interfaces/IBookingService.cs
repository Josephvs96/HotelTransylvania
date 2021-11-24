using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IBookingService
    {
        public void AddNewBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void RemoveBooking(Booking booking);
        public void CheckAndCleanDueBooings();
    }
}
