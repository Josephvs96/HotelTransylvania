using HotelTransylvania.CustomTypes;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.BookingMenu
{
    internal class SelectedBookingMenu : MenuBase
    {
        private readonly Booking _booking;
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;

        public SelectedBookingMenu(ConsoleUIService ui, IPaymentService paymentService, IBookingService bookingService, Booking booking) : base(ui)
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

            if (!booking.IsPayed) MenuItems.Insert(0, new MenuItem
            {
                Description = "Add payment",
                Execute = HandleAddPayment
            });

            // If the booking is payed then you cant delete it can only be viewed NOTHING ELSE! Well.... what ever
            if (booking.IsPayed)
            {
                MenuItems.RemoveRange(0, 2);
            }

            _booking = booking;
            _paymentService = paymentService;
            _bookingService = bookingService;

        }

        private void HandleAddPayment()
        {
            var response = _ui.GetUserInput<string>($"Total amount to pay: {_booking.TotalCost} - Type y to confirm payment.", ConsoleColor.Yellow, ValidationOptions.Required);
            if (response.ToLower() == "y")
            {
                _paymentService.AddPayment(_booking, new Payment { Guest = _booking.Guest, Amount = _booking.TotalCost, PayedAtUTC = DateTime.UtcNow });
                MenuItems.RemoveAt(0);
                _ui.PrintNotification("Payment added to booking!", ConsoleColor.Green);
            }
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
