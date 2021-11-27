using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _db.Guests.Include(g => g.Bookings).Where(g => g.Id == id && g.IsActive).FirstOrDefault();
        }

        public IEnumerable<Guest> GetGuestByName(string name)
        {
            return _db.Guests.Include(g => g.Bookings).Where(g => g.Name.Contains(name) && g.IsActive);
        }

        public void RemoveGuste(Guest guest)
        {
            var guestToRemoved = _db.Guests.Find(guest.Id);

            // TODO: Custom exceptions
            if (guestToRemoved is null) throw new Exception("Guest not found");

            if (guestToRemoved.HasActiveBookings()) throw new Exception("The guest has active bookings and cannot be removed");

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
