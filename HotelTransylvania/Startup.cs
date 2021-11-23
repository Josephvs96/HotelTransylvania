using HotelTransylvania.Services;
using HotelTransylvania.UI;

namespace HotelTransylvania
{
    internal class Startup
    {
        private readonly ConsoleUIService _ui;

        public Startup(ConsoleUIService ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            while (true)
            {
                var mainMenuCollection = new MainMenuCollection(_ui);
                mainMenuCollection.ShowItems();
                mainMenuCollection.GetInput();
            }
        }

    }
}
