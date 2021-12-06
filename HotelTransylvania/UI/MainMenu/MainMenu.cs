using HotelTransylvania.Services;
using HotelTransylvania.UI.RoomMenu;

namespace HotelTransylvania.UI.MainMenu
{
    internal class MainMenu : MenuBase
    {
        private readonly RoomsMenu _roomsMenu;
        private readonly GuestMenu.GuestMenu _guestMenu;
        private readonly BookingMenu.BookingMenu _bookingMenu;

        public MainMenu(ConsoleUIService ui, RoomsMenu roomsMenu, GuestMenu.GuestMenu guestMenu, BookingMenu.BookingMenu bookingMenu) : base(ui)
        {
            CollectionName = "Main Menu";
            MenuItems = new List<MenuItem>
            {
                new MenuItem { Description = "Rooms Managment", Execute = () => ShowSubMenu(_roomsMenu) },
                new MenuItem { Description = "Guests Managment", Execute = () => ShowSubMenu(_guestMenu) },
                new MenuItem { Description = "Bookings Managment", Execute = () => ShowSubMenu(_bookingMenu) },
                new MenuItem { Description = "Payments Managment", Execute = () => { } },
                new MenuItem { Description = "Exit", Execute = () => ExitCurrentMenu() }
            };
            _roomsMenu = roomsMenu;
            _guestMenu = guestMenu;
            _bookingMenu = bookingMenu;
        }

        public void ResetMenus()
        {
            _bookingMenu.ShouldBreak = false;
            _guestMenu.ShouldBreak = false;
            _roomsMenu.ShouldBreak = false;
        }

    }
}

