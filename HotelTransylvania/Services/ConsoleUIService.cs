using HotelTransylvania.Enums;
using System;
using System.Threading;

namespace HotelTransylvania.Services
{
    internal class ConsoleUIService
    {
        public string GetUserInput(string message, ConsoleColor fontColor = ConsoleColor.White, ValidationOptions validationOptions = ValidationOptions.None)
        {
            string output;

            if (validationOptions == ValidationOptions.Required)
            {
                do
                {
                    Console.ForegroundColor = fontColor;
                    Console.Write(message + " ");
                    output = Console.ReadLine();
                } while (string.IsNullOrEmpty(output));

                return output;
            }

            Console.ForegroundColor = fontColor;
            Console.Write(message + " ");
            return Console.ReadLine();

        }

        public void PrintToScreen(string message = "", ConsoleColor fontColor = ConsoleColor.White)
        {
            Console.ForegroundColor = fontColor;
            Console.WriteLine(message);
        }

        public void PrintNotification(string message, ConsoleColor fontColor = ConsoleColor.White)
        {
            PrintToScreen(message, fontColor);
            Thread.Sleep(1000);
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
    }
}
