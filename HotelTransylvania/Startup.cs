using HotelTransylvania.Services;
using HotelTransylvania.UI.MainMenu;

namespace HotelTransylvania
{
    internal class Startup
    {
        private readonly ConsoleUIService _ui;
        private readonly MainMenu _mainMenu;

        public Startup(ConsoleUIService ui, MainMenu mainMenu)
        {
            _ui = ui;
            _mainMenu = mainMenu;
        }

        public void Run()
        {
            while (!_mainMenu.ShouldBreak)
            {
                _mainMenu.ShowMenuHeader();
                _mainMenu.ShowItems();
                _mainMenu.GetInput();
            }
        }

    }
}
