using HotelTransylvania.Interfaces;
using HotelTransylvania.Services;
using System;
using System.Collections.Generic;

namespace HotelTransylvania.UI
{
    internal abstract class MenuCollection : IMenuCollection
    {
        private readonly ConsoleUIService _ui;

        public string CollectionName { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public bool ShouldBreak { get; set; } = false;

        public MenuCollection(ConsoleUIService ui)
        {
            _ui = ui;
        }

        public void GetInput()
        {
            int userInput;
            do
            {
                Console.WriteLine();
                Console.Write($"Enter a choice (1 - {MenuItems.Count}): ");
            } while (!int.TryParse(Console.ReadLine(), out userInput) ||
            userInput < 1 || userInput > MenuItems.Count);

            MenuItems[userInput - 1].Execute();
        }

        public void ShowItems()
        {
            _ui.PrintHeader(CollectionName);
            for (int i = 0; i < MenuItems.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {MenuItems[i].Description}");
            }
        }
    }
}
