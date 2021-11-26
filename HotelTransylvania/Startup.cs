using HotelTransylvania.Services;
using HotelTransylvania.UI.MainMenu;

namespace HotelTransylvania
{
    internal class Startup
    {
        private readonly ConsoleUIService _ui;
        private readonly MainMenuCollection _mainMenu;

        public Startup(ConsoleUIService ui, MainMenuCollection mainMenu)
        {
            _ui = ui;
            _mainMenu = mainMenu;
        }

        public void Run()
        {
            while (!_mainMenu.ShouldBreak)
            {
                _mainMenu.ShowItems();
                _mainMenu.GetInput();
            }
        }

    }
}
