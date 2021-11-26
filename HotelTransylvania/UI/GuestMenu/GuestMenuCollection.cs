using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using HotelTransylvania.Services;
using System;
using System.Collections.Generic;

namespace HotelTransylvania.UI.GuestMenu
{
    internal class GuestMenuCollection : MenuCollection
    {
        private readonly IGuestService _guestService;

        public GuestMenuCollection(ConsoleUIService ui, IGuestService guestService) : base(ui)
        {
            CollectionName = "Guests Managment";

            MenuItems = new List<MenuItem> {
                new MenuItem
                {
                    Description = "Search for guest by name",
                    Execute= ()=>{}
                },
                new MenuItem
                {
                    Description = "Search for guest by Id",
                    Execute = ()=>{}
                },
                new MenuItem
                {
                    Description = "Add new guest",
                    Execute = HandelAddNewGuest // ShowSubMenu(_newGuestMenu)
                },
                new MenuItem
                {
                    Description = "Update guest information",
                    Execute = ()=>{}
                },
                new MenuItem
                {
                    Description = "Delete guest",
                    Execute = ()=>{}
                },
                new MenuItem
                {
                    Description="Back..",
                    Execute = () => ExitCurrentMenu()
                }
            };
            _guestService = guestService;
        }

        private void HandelAddNewGuest()
        {
            var newGuest = new Guest();

            _ui.PrintToScreen("Add new guest", ConsoleColor.Cyan);
            newGuest.Name = _ui.GetUserInput("Name: ", validationOptions: Enums.ValidationOptions.Required);
            newGuest.PhoneNumber = _ui.GetUserInput("Phone number: ");
            newGuest.Email = _ui.GetUserInput("Email address: ");

            try
            {
                _guestService.AddGuste(newGuest);
                _ui.PrintNotification("New guest added successfuly!", ConsoleColor.Green);
            }
            catch (Exception)
            {
                _ui.PrintNotification("Couldn't add new guest, please try again!", ConsoleColor.Red);

            }
        }
    }
}
