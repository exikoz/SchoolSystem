using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.ConsoleUI
{
    public class LogInMenu
    {
        public static void LogIn()
        {
            // Admin log in menu options 
            List<string> menuOptions = new List<string>
            {
                "Log in"
            };

            while (true)
            {
                int? userInput = DisplayMenu.DisplayAndUseMenu(menuOptions, "Welcome to the school administration", true);
                switch (userInput)
                {
                    // Admin logs in
                    case 1:
                        //MainMenu.UseMainMenu();
                        break;

                    // Admin exits school system
                    case 0:
                        Console.WriteLine("\nThank you for using School System!");
                        return;
                }
            }
        }
    }
}
