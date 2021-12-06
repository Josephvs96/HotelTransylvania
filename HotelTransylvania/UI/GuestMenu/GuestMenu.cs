using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;

namespace HotelTransylvania.UI.GuestMenu
{
    internal class GuestMenu : MenuBase
    {
        private readonly IGuestService _guestService;
        private readonly IServiceProvider _serviceProvider;

        public GuestMenu(ConsoleUIService ui, IGuestService guestService, IServiceProvider serviceProvider) : base(ui)
        {
            _guestService = guestService;
            _serviceProvider = serviceProvider;
            CollectionName = "Guests Managment";
            MenuItems = new List<MenuItem> {
                new MenuItem
                {
                    Description = "Add new guest",
                    Execute = HandleAddNewGuest
                },
                new MenuItem
                {
                    Description = "Search for guest by name",
                    Execute = HandleSearchByName
                },
                new MenuItem
                {
                    Description = "Search for guest by id",
                    Execute = HandleSearchById
                },
                new MenuItem
                {
                    Description="Back..",
                    Execute = () => ExitCurrentMenu()
                }
            };
        }

        private void HandleAddNewGuest()
        {
            var newGuest = new Guest();
            _ui.PrintToScreen("Add new guest", ConsoleColor.Cyan);
            newGuest.Name = _ui.GetUserInput<string>("Name: ", validationOptions: CustomTypes.ValidationOptions.Required);
            newGuest.PhoneNumber = _ui.GetUserInput<string>("Phone number: ");
            newGuest.Email = _ui.GetUserInput<string>("Email address: ");

            try
            {
                _guestService.AddGuste(newGuest);
                _ui.ClearConsole();
                _ui.PrintNotification("New guest added successfuly!", ConsoleColor.Green);
            }
            catch (Exception)
            {
                _ui.PrintNotification("Couldn't add new guest, please try again!", ConsoleColor.Red);

            }
        }

        private void HandleSearchByName()
        {
            _ui.PrintToScreen("Search by name", ConsoleColor.Cyan);
            var nameToSearch = _ui.GetUserInput<string>("Name: ", validationOptions: CustomTypes.ValidationOptions.Required);
            var guestsFound = _guestService.GetGuestByName(nameToSearch);

            _ui.PrintToScreen();

            if (guestsFound.Count() == 0)
            {
                _ui.PrintNotification($"No guests by the name {nameToSearch} could be found", ConsoleColor.Red);
                return;
            }

            _ui.PrintToScreen("Guests found", ConsoleColor.Cyan);
            var selectedUser = _ui.PrintMultipleChoiceMenuAndGetInput(guestsFound, "Please select a guest");

            ShowSubMenu(new SelectedGuestMenu(_ui, _guestService, selectedUser), () => _ui.PrintToScreen("Selected user: " + selectedUser, ConsoleColor.Cyan));
        }

        private void HandleSearchById()
        {
            try
            {
                _ui.PrintToScreen("Search by Id", ConsoleColor.Cyan);
                var id = _ui.GetUserInput<int>("Enter the guests id: ", validationOptions: CustomTypes.ValidationOptions.Required);
                var guestFound = _guestService.GetGuestById(id);
                ShowSubMenu(new SelectedGuestMenu(_ui, _guestService, guestFound), () => _ui.PrintToScreen("Selected user: " + guestFound, ConsoleColor.Cyan));
                _ui.PrintToScreen();
            }
            catch (Exception)
            {
                _ui.PrintNotification($"No guest with this id could be found", ConsoleColor.Red);
            }
        }
    }
}
