using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.BookingMenu
{
    internal class BookingMenu : MenuBase
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;
        private readonly IPaymentService _paymentService;

        public BookingMenu(ConsoleUIService ui, IBookingService bookingService, IRoomService roomService, IGuestService guestService, IPaymentService paymentService) : base(ui)
        {
            CollectionName = "Booking Menu";
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Description = "Make new booking",
                    Execute = HandleNewBooking
                },
                new MenuItem
                {
                    Description = "Search for a booking by id",
                    Execute = HandleSearchByBookingId
                },
                new MenuItem
                {
                    Description = "View bookings by guest id",
                    Execute = HandleViewAllBookingsByGuestId
                },
                new MenuItem
                {
                    Description = "Back..",
                    Execute = ExitCurrentMenu
                }

            };
            _bookingService = bookingService;
            _roomService = roomService;
            _guestService = guestService;
            _paymentService = paymentService;
        }

        private void HandleViewAllBookingsByGuestId()
        {
            try
            {
                _ui.PrintToScreen("View guests booking history", ConsoleColor.Cyan);
                var guestId = _ui.GetUserInput<int>("Enter guest id: ", validationOptions: CustomTypes.ValidationOptions.Required);
                var bookingsFound = _bookingService.GetBookingsByGuestId(guestId);
                var selectedBooking = _ui.PrintMultipleChoiceMenuAndGetInput(bookingsFound);
                var selectedBookingMenu = new SelectedBookingMenu(_ui, _paymentService, _bookingService, selectedBooking);
                ShowSubMenu(selectedBookingMenu, () => _ui.PrintToScreen(selectedBooking.ToString(), ConsoleColor.Cyan));
            }
            catch (Exception)
            {
                _ui.PrintNotification("No bookings could by found by this id", ConsoleColor.Red);
            }
        }

        private void HandleSearchByBookingId()
        {
            try
            {
                _ui.PrintToScreen("View booking by id", ConsoleColor.Cyan);
                var bookingId = _ui.GetUserInput<int>("Enter the booking id", validationOptions: CustomTypes.ValidationOptions.Required);
                var bookingFound = _bookingService.GetBookingById(bookingId);
                var selectedBookingMenu = new SelectedBookingMenu(_ui, _paymentService, _bookingService, bookingFound);
                ShowSubMenu(selectedBookingMenu, () => _ui.PrintToScreen(bookingFound.ToString(), ConsoleColor.Cyan));
            }
            catch (Exception)
            {
                _ui.PrintNotification("No bookings could by found by this id", ConsoleColor.Red);
            }
        }

        private void HandleNewBooking()
        {
            try
            {
                _ui.PrintToScreen("Make new booking", ConsoleColor.Cyan);
                int guestId = _ui.GetUserInput<int>("Enter the guests Id: ", validationOptions: CustomTypes.ValidationOptions.Required);
                var guest = _guestService.GetGuestById(guestId);
                var numberOfPeopleToBook = _ui.GetUserInput<int>("Enter the number of people to book for: ", validationOptions: CustomTypes.ValidationOptions.Required);
                var fromDate = _ui.GetUserInput<DateTime>("Enter checking in date (yyyy-mm-dd): ", validationOptions: CustomTypes.ValidationOptions.Required).AddHours(15);
                var toDate = _ui.GetUserInput<DateTime>("Enter checking out date (yyyy-mm-dd): ", validationOptions: CustomTypes.ValidationOptions.Required).AddHours(12);
                var bookingDateRange = new DateTimeRange(fromDate, toDate);

                var roomsToBook = _roomService.GetAvailableRoomsByDateAndNumberOfPeople(bookingDateRange, numberOfPeopleToBook);
                var roomToBook = _ui.PrintMultipleChoiceMenuAndGetInput(roomsToBook, "Rooms found on this date", ConsoleColor.Cyan);

                if (roomToBook is null) return;

                var newBooking = new Booking();
                newBooking.From = fromDate;
                newBooking.To = toDate;
                newBooking.Guest = _guestService.GetGuestById(1);
                newBooking.Room = roomToBook;
                newBooking.TotalCost = newBooking.CalculateTotalCost();

                _bookingService.AddNewBooking(newBooking);
                _ui.PrintNotification($"Room {roomToBook.RoomNumber} " +
                    $"booked for {newBooking.BookingLength()} days " +
                    $"for total of {newBooking.TotalCost.ToString("00.00")}kr", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                _ui.PrintNotification(e.Message, ConsoleColor.Red);
            }
        }
    }
}
