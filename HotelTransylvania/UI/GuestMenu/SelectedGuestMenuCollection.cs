using HotelTransylvania.Enums;
using HotelTransylvania.Helpers;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.GuestMenu
{
    internal class SelectedGuestMenuCollection : MenuCollection
    {
        private readonly IGuestService _guestService;
        private readonly Guest _guest;

        public SelectedGuestMenuCollection(ConsoleUIService ui, IGuestService guestService, Guest guest) : base(ui)
        {
            _guestService = guestService;
            _guest = guest;

            CollectionName = "Guest Menu";
            MenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Description = "Update guest",
                    Execute = HandleUpdateGuest
                },
                new MenuItem
                {
                    Description = "Delete guest",
                    Execute = HandleDeleteGuest
                },
                new MenuItem
                {
                    Description = "Back..",
                    Execute = ExitCurrentMenu
                }
            };
        }

        private void HandleUpdateGuest()
        {
            _ui.PrintToScreen("Please enter the values required to be changed, leave empty to use the current value", ConsoleColor.Cyan);
            var newName = _ui.GetUserInput<string>($"Name (Current: {_guest.Name}): ");
            var newEmail = _ui.GetUserInput<string>($"Email (Current: {_guest.Email.StringHasValue("No value")}): ");
            var newPhoneNumber = _ui.GetUserInput<string>($"Phone Number (Current: {_guest.PhoneNumber.StringHasValue("No value")}): ");

            _guest.Name = string.IsNullOrEmpty(newName) ? _guest.Name : newName;
            _guest.Email = string.IsNullOrEmpty(newEmail) ? _guest.Email : newEmail;
            _guest.PhoneNumber = string.IsNullOrEmpty(newPhoneNumber) ? _guest.PhoneNumber : newPhoneNumber;

            try
            {
                _guestService.UpdateGuste(_guest);
                _ui.PrintNotification("Guest updated succssfully", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                _ui.PrintNotification($"Error while updating the guest infomration, Error: {e.Message}", ConsoleColor.Red);
            }
        }

        private void HandleDeleteGuest()
        {
            var deleteConfirm = _ui.GetUserInput<string>($"Are you sure you want to delete guest {_guest.Name} from the database? (Y-N)", validationOptions: ValidationOptions.Required);
            if (!string.IsNullOrEmpty(deleteConfirm) && deleteConfirm.ToLower() == "y")
            {
                try
                {
                    _guestService.RemoveGuste(_guest);
                    _ui.PrintNotification("Guest removed succssfully", ConsoleColor.Green);
                    ExitCurrentMenu();
                }
                catch (Exception e)
                {
                    _ui.PrintNotification($"Error while removing a guest, Error: {e.Message}", ConsoleColor.Red);
                }
            }
        }
    }
}
