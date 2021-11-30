using HotelTransylvania.Services;

namespace HotelTransylvania.UI
{
    internal abstract class MenuCollection
    {
        protected readonly ConsoleUIService _ui;

        public string CollectionName { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public bool ShouldBreak { get; set; } = false;

        public MenuCollection(ConsoleUIService ui)
        {
            _ui = ui;
        }

        protected void ShowSubMenu<T>(T subMenu, Action action = null) where T : MenuCollection
        {
            _ui.ClearConsole();
            while (!subMenu.ShouldBreak)
            {
                subMenu.ShowMenuHeader();

                if (action != null)
                    action.Invoke();

                _ui.PrintToScreen();
                subMenu.ShowItems();
                subMenu.GetInput();
            }
        }

        protected void ExitCurrentMenu()
        {
            ShouldBreak = true;
            _ui.ClearConsole();
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
            for (int i = 0; i < MenuItems.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {MenuItems[i].Description}");
            }
        }

        public void ShowMenuHeader()
        {
            _ui.PrintHeader(CollectionName);
        }
    }
}
