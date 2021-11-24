using HotelTransylvania.Enums;
using HotelTransylvania.Models;
using System;
using System.Collections.Generic;

namespace HotelTransylvania.Interfaces
{
    public interface IRoomService
    {
        public IEnumerable<Room> GetAllRooms();
        public IEnumerable<Room> GetAllAvailableRooms();
        public IEnumerable<Room> GetAllRoomsByType(RoomTypes roomType);
        public IEnumerable<Room> GetAllAvailableRoomsByType(RoomTypes roomType);
        public IEnumerable<Room> GetAvailableRoomsByDateAndNumberOfPeople(DateTime dateTime, int numberOfPeople);
        public IEnumerable<Room> GetAvailableRoomsByDateAndNumberOfPeople(DateTime startDate, DateTime endDate, int numberOfPeople);
        public void AddRoom(Room room);
        public void UpdateRoom(Room room);
        public void DeleteRoom(Room room);
    }
}
