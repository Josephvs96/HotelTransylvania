using HotelTransylvania.DataAccess;
using HotelTransylvania.Enums;
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

        public IEnumerable<Room> GetAllRooms()
        {
            return _db.Rooms.Include(r => r.RoomProperties)
                            .ThenInclude(rp => rp.ExtraBeds)
                            .Include(r => r.RoomType)
                            .Include(r => r.Bookings);
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
                    return _db.Rooms.Include(r => r.Bookings)
                                    .Include(r => r.RoomType)
                                    .Where(r => r.IsRoomAvaiableByDateRange(bookingRange) && r.RoomType.Type == RoomTypes.Single)
                                    .Include(r => r.RoomProperties);

                case > 1:
                    return _db.Rooms.Include(r => r.Bookings)
                                    .Include(r => r.RoomProperties)
                                    .ThenInclude(rp => rp.ExtraBeds)
                                    .Include(r => r.RoomType)
                                    .Where(r =>
                                    r.IsRoomAvaiableByDateRange(bookingRange) &&
                                    r.RoomType.Type == RoomTypes.Double &&
                                    r.RoomProperties.ExtraBeds.NumberOfExtraBeds >= numberOfPeople);
            }
            return null;
        }

        public Room GetRoomById(int roomId)
        {
            var roomFound = _db.Rooms.Where(r => r.Id == roomId)
                            .Include(r => r.RoomProperties)
                            .ThenInclude(rp => rp.ExtraBeds)
                            .Include(r => r.RoomType).FirstOrDefault();

            return roomFound ?? throw new RoomNotFoundException();
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

        public void DeleteRoom(Room room)
        {
            _db.Rooms.Update(room);
            _db.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            _db.Rooms.Update(room);
            _db.SaveChanges();
        }
    }
}
