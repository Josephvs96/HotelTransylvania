using HotelTransylvania.CustomTypes;
using HotelTransylvania.Helpers;

namespace HotelTransylvania.Services
{
    internal class ConsoleUIService
    {
        public T GetUserInput<T>(string message, ConsoleColor fontColor = ConsoleColor.White, ValidationOptions validationOptions = ValidationOptions.None)
        {
            string consoleInput;
            T output;

            Console.ForegroundColor = fontColor;
            Console.Write(message + " ");

            if (validationOptions == ValidationOptions.Required)
            {
                do
                {
                    consoleInput = Console.ReadLine();
                } while (string.IsNullOrEmpty(consoleInput));
            }
            else
                consoleInput = Console.ReadLine();

            try
            {

                if (string.IsNullOrEmpty(consoleInput) && typeof(T).IsNumeric())
                    return (T)Convert.ChangeType(-1, typeof(T));

                output = (T)Convert.ChangeType(consoleInput, typeof(T));
                return output;
            }
            catch (Exception)
            {
                PrintNotification("Please enter a valid value", ConsoleColor.Red);
                return GetUserInput<T>(message, fontColor, validationOptions);
            }
        }

        public void PrintToScreen(string message = "", ConsoleColor fontColor = ConsoleColor.White)
        {
            Console.ForegroundColor = fontColor;
            Console.WriteLine(message);
        }

        public void PrintNotification(string message, ConsoleColor fontColor = ConsoleColor.White)
        {
            Console.ForegroundColor = fontColor;
            Console.Write(message);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
            ClearConsole();
        }

        public void PrintHeader(string currentMenu)
        {
            PrintToScreen("=====================================================");
            PrintToScreen("   Welcome to Hotel Transylvania managment system");
            PrintToScreen("=====================================================");
            PrintToScreen();
            PrintToScreen($"===================== {currentMenu} =====================");
            PrintToScreen();
        }

        internal void ClearConsole()
        {
            Console.Clear();
        }

        public T PrintMultipleChoiceMenuAndGetInput<T>(IEnumerable<T> multipleChoices, string message = "", ConsoleColor fontColor = ConsoleColor.White)
        {
            if (!string.IsNullOrEmpty(message))
                PrintToScreen(message, fontColor);

            int choicesCount = multipleChoices.Count();

            if (choicesCount == 0)
            {
                PrintNotification("No items could be found...", ConsoleColor.Red);
                return default(T);
            }

            for (int i = 0; i < choicesCount; i++)
            {
                Console.WriteLine($"  {i + 1}. {multipleChoices.ElementAt(i)}");
            }

            int userInput;
            do
            {
                Console.WriteLine();
                Console.Write($"Enter a choice (1 - {choicesCount}): ");
            } while (!int.TryParse(Console.ReadLine(), out userInput) ||
            userInput < 1 || userInput > choicesCount);

            return multipleChoices.ElementAt(userInput - 1);
        }
    }
}
