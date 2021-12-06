using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.BookingMenu
{
    internal class SelectedBookingMenu : MenuBase
    {
        private readonly Booking _booking;
        private readonly IBookingService _bookingService;

        public SelectedBookingMenu(ConsoleUIService ui, IBookingService bookingService, Booking booking) : base(ui)
        {
            CollectionName = "Booking Menu";
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Description = "Change booking date",
                    Execute = HandleChangeBooking
                },
                 new MenuItem
                {
                    Description = "Cancel booking",
                    Execute = HandleCancelBooking
                },
                new MenuItem
                {
                    Description = "Back..",
                    Execute = ExitCurrentMenu
                }
            };

            _booking = booking;
            _bookingService = bookingService;

        }

        private void HandleChangeBooking()
        {
            try
            {
                _ui.PrintToScreen("Type in the updated information otherwize leave empty to use the current value", ConsoleColor.Cyan);
                var fromDate = _ui.GetUserInput<DateTime>($"Enter checking in date (Current: {_booking.From.ToShortDateString()}) (yyyy-mm-dd): ");
                var toDate = _ui.GetUserInput<DateTime>($"Enter checking out date (Current: {_booking.To.ToShortDateString()}) (yyyy-mm-dd): ");
                _booking.From = fromDate == default(DateTime) ? _booking.From : fromDate.AddHours(15);
                _booking.To = toDate == default(DateTime) ? _booking.To : toDate.AddHours(12);
                _bookingService.UpdateBooking(_booking);
                _ui.PrintNotification("Booking updated successfully!", ConsoleColor.Green);
            }
            catch (Exception)
            {
                _ui.PrintNotification("Error while updating a booking!", ConsoleColor.Red);
            }
        }

        private void HandleCancelBooking()
        {
            try
            {
                var confirmation = _ui.GetUserInput<string>("Are you sure you want to cancel this booking? (y/n)");
                if (confirmation == "y") _bookingService.RemoveBooking(_booking);
                else return;

                _ui.PrintNotification("Booking canceled!", ConsoleColor.Green);
                ExitCurrentMenu();
            }
            catch (Exception)
            {
                _ui.PrintNotification("Error while canceling a booking!", ConsoleColor.Red);
            }

        }
    }
}
