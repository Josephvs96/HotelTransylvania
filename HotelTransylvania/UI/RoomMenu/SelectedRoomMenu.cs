using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.RoomMenu
{
    internal class SelectedRoomMenu : MenuBase
    {
        private readonly IRoomService _roomService;
        private Room _room;

        public SelectedRoomMenu(ConsoleUIService ui, IRoomService roomService, Room room) : base(ui)
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Description = "Change room price",
                    Execute = HandleEditRoomPrice
                },
                new MenuItem
                {
                    Description = "Remove room from service",
                    Execute = HandleDeactivateRoom
                },
                new MenuItem
                {
                    Description = "Restore room to service",
                    Execute = HandleActiveRoom
                },
                new MenuItem
                {
                    Description = "Back..",
                    Execute = ExitCurrentMenu
                }
            };

            CollectionName = "Room Managment";
            _roomService = roomService;
            _room = room;
        }

        private void HandleActiveRoom()
        {
            try
            {
                _room.IsActive = true;
                _roomService.UpdateRoom(_room);
                _ui.PrintNotification("Room is now in serivce", ConsoleColor.Green);
            }
            catch (Exception)
            {
                _ui.PrintNotification("Error while activating room", ConsoleColor.Red);
            }
        }

        private void HandleDeactivateRoom()
        {
            try
            {
                _room.IsActive = false;
                _roomService.UpdateRoom(_room);
                _ui.PrintNotification("Room is now out of service", ConsoleColor.Green);
            }
            catch (Exception)
            {
                _ui.PrintNotification("Error while removing room", ConsoleColor.Red);
            }
        }

        private void HandleEditRoomPrice()
        {
            try
            {
                _ui.PrintToScreen("Please enter the values required to be changed, leave empty to use the current value", ConsoleColor.Cyan);
                var newPrice = _ui.GetUserInput<decimal>($"Enter the new room price per night (Current: {_room.PricePerNight}kr): ");
                _room.PricePerNight = newPrice == -1 ? _room.PricePerNight : newPrice;
                _roomService.UpdateRoom(_room);
                _ui.PrintNotification("Room price updated!", ConsoleColor.Green);
            }
            catch (Exception)
            {

                _ui.PrintNotification("Error while updating room price", ConsoleColor.Red);
            }
        }
    }
}
