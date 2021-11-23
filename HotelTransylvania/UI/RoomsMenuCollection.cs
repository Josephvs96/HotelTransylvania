using HotelTransylvania.Services;
using System.Collections.Generic;

namespace HotelTransylvania.UI
{
    internal class RoomsMenuCollection : MenuCollection
    {
        public RoomsMenuCollection(ConsoleUIService ui) : base(ui)
        {
            CollectionName = "Rooms Managment";
            MenuItems = new List<MenuItem>
            {
                new MenuItem{Description="Book a room", Execute = HandelRoomBooking},
                new MenuItem{Description="View available rooms", Execute=HandelViewAvailableRooms},
                new MenuItem{Description="Add a new room", Execute=HandelAddRoom},
                new MenuItem{Description="Edit a room", Execute=HandelAddRoom},
                new MenuItem{Description="Back..", Execute=()=>{ ShouldBreak=true; }}
            };
        }

        private void HandelRoomBooking()
        {

        }

        private void HandelViewAvailableRooms()
        {

        }

        private void HandelAddRoom()
        {

        }

        private void HandelEditRoom()
        {

        }
    }
}
