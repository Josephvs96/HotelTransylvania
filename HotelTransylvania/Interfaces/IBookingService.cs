using HotelTransylvania.Models;
using System.Collections.Generic;

namespace HotelTransylvania.Interfaces
{
    public interface IBookingService
    {
        public Booking GetBookingById(int id);
        public IEnumerable<Booking> GetBookingsByGuest(Guest guest);
        public void AddNewBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public void RemoveBooking(Booking booking);
        public void CheckAndCleanDueBooings();
    }
}
