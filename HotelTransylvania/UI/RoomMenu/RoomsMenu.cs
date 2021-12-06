using HotelTransylvania.CustomTypes;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.RoomMenu
{
    internal class RoomsMenu : MenuBase
    {
        private readonly IRoomService _roomService;

        public RoomsMenu(ConsoleUIService ui, IRoomService roomService) : base(ui)
        {
            CollectionName = "Rooms Managment";
            MenuItems = new List<MenuItem>
            {
                new MenuItem{Description="Search for rooms by type", Execute=HandleSearchByType},
                new MenuItem{Description="Search for rooms by number", Execute=HandleSearchByNumber},
                new MenuItem{Description="Add a new room", Execute=HandleAddRoom},
                new MenuItem{Description="Back..", Execute= ExitCurrentMenu}
            };
            _roomService = roomService;
        }

        private void HandleSearchByType()
        {
            var selectedType = _ui.PrintMultipleChoiceMenuAndGetInput(_roomService.GetRoomTypes(), "Select which type you like to view", ConsoleColor.Cyan);
            var rooms = _roomService.GetAllRoomsByType(selectedType.Type);
            var selectedRoom = _ui.PrintMultipleChoiceMenuAndGetInput(rooms, "Select a room", ConsoleColor.Cyan);
            var selectedRoomMenu = new SelectedRoomMenu(_ui, _roomService, selectedRoom);
            ShowSubMenu(selectedRoomMenu, () => _ui.PrintToScreen($"Selected room: {selectedRoom}", ConsoleColor.Cyan));
        }

        private void HandleSearchByNumber()
        {
            var enteredRoomNumber = _ui.GetUserInput<int>("Enter the room number");
            var selectedRoom = _roomService.GetRoomByRoomNumber(enteredRoomNumber);
            var selectedRoomMenu = new SelectedRoomMenu(_ui, _roomService, selectedRoom);
            ShowSubMenu(selectedRoomMenu, () => _ui.PrintToScreen($"Selected room: {selectedRoom}", ConsoleColor.Cyan));
        }

        private void HandleAddRoom()
        {
            var newRoom = new Room();
            _ui.PrintToScreen("Add new room", ConsoleColor.Cyan);

            var selectedRoomType = _ui.PrintMultipleChoiceMenuAndGetInput(_roomService.GetRoomTypes(), "Please select the room type");
            var roomProprties = new RoomProperties();
            roomProprties.RoomSize = _ui.GetUserInput<int>("Enter the size of the room (\u33A1): ");
            roomProprties.NumberOfWindows = _ui.GetUserInput<int>("Enter the number of windows in the room: ");

            roomProprties.ExtraBeds = new ExtraBeds(selectedRoomType.Type);
            if (selectedRoomType.Type == RoomTypes.Double)
                roomProprties.ExtraBeds.NumberOfExtraBeds = _ui.GetUserInput<int>("Enter the number of extra beds available to the room");

            newRoom.RoomType = selectedRoomType;
            newRoom.RoomProperties = roomProprties;
            newRoom.RoomNumber = _ui.GetUserInput<int>("Enter the room number: ");
            newRoom.PricePerNight = _ui.GetUserInput<decimal>("Enter the room price per night (kr): ");

            try
            {
                _roomService.AddRoom(newRoom);
                _ui.PrintNotification("Room added succussfully", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                _ui.PrintNotification("Error while adding a room " + e.Message, ConsoleColor.Red);
            }
        }
    }
}
