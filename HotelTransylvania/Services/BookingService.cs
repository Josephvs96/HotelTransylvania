using HotelTransylvania.DataAccess;
using HotelTransylvania.Exceptions;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelTransylvania.Services
{
    internal class BookingService : IBookingService
    {
        private readonly HotelDbContext _db;

        public BookingService(HotelDbContext db)
        {
            _db = db;
        }
        public void AddNewBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }

        public void CheckAndCleanDueBooings()
        {
            throw new NotImplementedException();
        }

        public Booking GetBookingById(int id)
        {
            return _db.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Payment)
                .Include(b => b.Room)
                .Where(b => b.Id == id).FirstOrDefault() ?? throw new BookingNotFoundException();
        }

        public IEnumerable<Booking> GetBookingsByGuestId(int id)
        {
            var bookingsFound = _db.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Payment)
                .Include(b => b.Room)
                .Where(b => b.Guest.Id == id && b.To.AddDays(10) > DateTime.UtcNow);
            return bookingsFound.Any() ? bookingsFound : throw new BookingNotFoundException();
        }

        public IEnumerable<Booking> GetOldDueBookings()
        {
            return _db.Bookings.Where(b => !b.IsPayed && b.To.AddDays(10) < DateTime.UtcNow);
        }

        public void RemoveBooking(Booking booking)
        {
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            _db.Bookings.Update(booking);
            _db.SaveChanges();
        }

        public async Task RemoveBookingAsync(Booking booking)
        {
            _db.Bookings.Remove(booking);
            await _db.SaveChangesAsync();
        }
    }
}
