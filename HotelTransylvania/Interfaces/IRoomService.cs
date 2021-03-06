using HotelTransylvania.CustomTypes;
using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IRoomService
    {
        public Room GetRoomByRoomNumber(int roomNumber);
        public IEnumerable<Room> GetAllRoomsByType(RoomTypes roomType);
        public IEnumerable<Room> GetAvailableRoomsByDateAndNumberOfPeople(DateTimeRange bookingRange, int numberOfPeople);
        public IEnumerable<RoomType> GetRoomTypes();
        public void AddRoom(Room room);
        public void UpdateRoom(Room room);
    }
}
