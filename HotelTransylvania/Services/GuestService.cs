using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
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
            return _db.Guests.Where(g => g.Id == id).FirstOrDefault();
        }

        public IEnumerable<Guest> GetGuestByName(string name)
        {
            return _db.Guests.Where(g => g.Name.Contains(name));
        }

        public void RemoveGuste(Guest guest)
        {
            var guestToRemove = _db.Guests.Find(guest);

            if (guestToRemove is null) throw new Exception("Guest not found");

            guestToRemove.IsActive = false;

            _db.Guests.Update(guestToRemove);

            _db.SaveChanges();
        }

        public void UpdateGuste(Guest guest)
        {
            var guestToUpdate = _db.Guests.Find(guest);

            if (guestToUpdate is null) throw new Exception("Guest not found");

            guestToUpdate.IsActive = false;

            _db.Guests.Update(guestToUpdate);

            _db.SaveChanges();
        }
    }
}
