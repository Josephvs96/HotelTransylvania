using HotelTransylvania.Services;
using HotelTransylvania.UI.GuestMenu;
using HotelTransylvania.UI.RoomMenu;

namespace HotelTransylvania.UI.MainMenu
{
    internal class MainMenuCollection : MenuCollection
    {
        private readonly RoomsMenuCollection _roomsMenu;
        private readonly GuestMenuCollection _guestMenu;

        public MainMenuCollection(ConsoleUIService ui, RoomsMenuCollection roomsMenu, GuestMenuCollection guestMenu) : base(ui)
        {
            CollectionName = "Main Menu";

            MenuItems = new List<MenuItem>
            {
                new MenuItem { Description = "Rooms Managment", Execute = () => ShowSubMenu(_roomsMenu) },
                new MenuItem { Description = "Guests Managment", Execute = () => ShowSubMenu(_guestMenu) },
                new MenuItem { Description = "Bookings Managment", Execute = () => { } },
                new MenuItem { Description = "Payments Managment", Execute = () => { } },
                new MenuItem { Description = "Exit", Execute = () => ExitCurrentMenu() }
            };
            _roomsMenu = roomsMenu;
            _guestMenu = guestMenu;
        }
    }
}

