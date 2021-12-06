using HotelTransylvania.DataAccess;
using HotelTransylvania.Exceptions;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelTransylvania.Services
{
    internal class GuestService : IGuestService
    {
        private readonly HotelDbContext _db;

        public GuestService(HotelDbContext db)
        {
            _db = db;
        }

        public void AddGuste(Guest guest)
        {
            _db.Guests.Add(guest);
            _db.SaveChanges();
        }

        public Guest GetGuestById(int id)
        {
            return _db.Guests.Include(g => g.Bookings).Where(g => g.Id == id && g.IsActive).FirstOrDefault() ?? throw new GuestNotFoundException();
        }

        public IEnumerable<Guest> GetGuestByName(string name)
        {
            return _db.Guests.Include(g => g.Bookings).Where(g => g.Name.Contains(name) && g.IsActive);
        }

        public void RemoveGuste(Guest guest)
        {
            var guestToRemoved = _db.Guests.Find(guest.Id);

            if (guestToRemoved is null) throw new GuestNotFoundException();

            if (guestToRemoved.HasActiveBookings()) throw new GuestHasActiveBookingsException();

            guestToRemoved.IsActive = false;

            _db.Guests.Update(guestToRemoved);

            _db.SaveChanges();
        }

        public void UpdateGuste(Guest guest)
        {
            var guestToUpdate = _db.Guests.Find(guest.Id);

            if (guestToUpdate is null) throw new Exception("Guest not found");

            _db.Guests.Update(guestToUpdate);

            _db.SaveChanges();
        }
    }
}
