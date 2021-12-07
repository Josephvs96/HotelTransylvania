using HotelTransylvania.CustomTypes;
using HotelTransylvania.DataAccess;
using HotelTransylvania.Exceptions;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelTransylvania.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelDbContext _db;
        public RoomService(HotelDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Room> GetAllRoomsByType(RoomTypes roomType)
        {
            return _db.Rooms.Include(r => r.RoomType)
                            .Where(r => r.RoomType.Type == roomType)
                            .Include(r => r.RoomProperties)
                            .ThenInclude(rp => rp.ExtraBeds)
                            .Include(r => r.Bookings);
        }

        public IEnumerable<Room> GetAvailableRoomsByDateAndNumberOfPeople(DateTimeRange bookingRange, int numberOfPeople)
        {
            switch (numberOfPeople)
            {
                case 1:
                    {
                        return _db.Rooms.Include(r => r.Bookings.Where(b => b.To > DateTime.UtcNow))
                                    .Include(r => r.RoomType)
                                    .Include(r => r.RoomProperties)
                                    .Where(r =>
                                    r.IsActive &&
                                    r.RoomType.Type == RoomTypes.Single)
                                    .ToList()
                                    .Where(r => r.IsRoomAvaiableByDateRange(bookingRange));
                    }


                case > 1:
                    {
                        return _db.Rooms.Include(r => r.Bookings.Where(b => b.To > DateTime.UtcNow))
                                    .Include(r => r.RoomProperties)
                                    .ThenInclude(rp => rp.ExtraBeds)
                                    .Include(r => r.RoomType)
                                    .Where(r =>
                                    r.IsActive &&
                                    r.RoomType.Type == RoomTypes.Double &&
                                    r.RoomProperties.ExtraBeds.NumberOfExtraBeds >= numberOfPeople - 2).ToList()
                                    .Where(r => r.IsRoomAvaiableByDateRange(bookingRange));
                    }

            }
            return null;
        }

        public Room GetRoomByRoomNumber(int roomNumber)
        {
            var roomFound = _db.Rooms.Where(r => r.RoomNumber == roomNumber)
                           .Include(r => r.RoomProperties)
                           .ThenInclude(rp => rp.ExtraBeds)
                           .Include(r => r.RoomType)
                           .FirstOrDefault();

            return roomFound ?? throw new RoomNotFoundException();
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            return _db.RoomTypes.OrderBy(t => t.Type);
        }
        public void AddRoom(Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _db.Rooms.Update(room);
            _db.SaveChanges();
        }
    }
}
