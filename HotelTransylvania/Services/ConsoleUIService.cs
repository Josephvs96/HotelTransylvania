using System;

namespace HotelTransylvania.Services
{
    internal class ConsoleUIService
    {
        public string GetUserInput(string message, ConsoleColor fontColor = ConsoleColor.White)
        {
            Console.Write(message + " ");
            return Console.ReadLine();
        }

        public void PrintToScreen(string message = "", ConsoleColor fontColor = ConsoleColor.White)
        {
            Console.WriteLine(message);
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
    }
}
