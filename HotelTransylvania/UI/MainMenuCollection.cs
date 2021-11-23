using HotelTransylvania.Interfaces;
using HotelTransylvania.Services;
using System;
using System.Collections.Generic;

namespace HotelTransylvania.UI
{
    internal class MainMenuCollection : MenuCollection, IMenuCollection
    {
        public MainMenuCollection(ConsoleUIService ui) : base(ui)
        {
            CollectionName = "Main Menu";

            MenuItems = new List<MenuItem>
            {
                new MenuItem { Description = "Rooms Managment", Execute= () =>
                    {
                        var roomsMenu = new RoomsMenuCollection(ui);
                        while(!roomsMenu.ShouldBreak)
                        {
                            roomsMenu.ShowItems();
                            roomsMenu.GetInput();
                        }
                    }
                },
                new MenuItem { Description = "Guests Managment", Execute = () => { } },
                new MenuItem { Description = "Bookings Managment", Execute = () => { } },
                new MenuItem { Description = "Payments Managment", Execute = () => { } },
                new MenuItem { Description = "Exit", Execute = () => { Environment.Exit(0);} }
            };
        }
    }
}

