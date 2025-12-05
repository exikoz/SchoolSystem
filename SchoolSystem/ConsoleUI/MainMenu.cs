using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class MainMenu
    {
        public enum CrudAction
        {
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4
        };

        public enum EntityType
        {
            Student = 1,
            Report = 2,
            Classroom = 3,
            Teacher = 4,
            Course = 5
        };

        public static void UseMainMenu()
        {
            // Main menu options 
            List<string> menuOptions = new List<string>
            {
                "CRUD-operations",
                "Assign course schedule",
                "Register student into a course",
                "Student overview",
                "List active courses and participating students",
                "Student ratio between passed and failed"
            };

            // Crud menu options 
            List<string> crudMenuOptions = new List<string>
            {
                "Create",
                "Read",
                "Update",
                "Delete"
            };

            // Entity menu options
            List<string> entityMenuOptions = new List<string>
            {
                "Student",
                "Report",
                "Classroom",
                "Teacher",
                "Course"
            };
    

            while (true)
            {
                bool exitMenu = false;
                int? userInput = DisplayMenu.DisplayAndUseMenu(menuOptions, "Main menu", true);
                switch (userInput)
                {
                    // CRUD
                    case 1:
                        while (!exitMenu)
                        {
                            int? userCrudInput = DisplayMenu.DisplayAndUseMenu(crudMenuOptions, "Choose CRUD action", false);

                            if (userCrudInput == 0)
                            {
                                exitMenu = true;
                                break;
                            }

                            CrudAction action = (CrudAction)userCrudInput;

                            int? userEntityInput = DisplayMenu.DisplayAndUseMenu(entityMenuOptions, "Choose entity", false);
                            if (userEntityInput == null || userEntityInput == 0) continue;

                            EntityType entity = (EntityType)userEntityInput;

                            switch (action)
                            {
                                case CrudAction.Create:
                                    // Create Method here. Input - Entity
                                    Console.WriteLine($"Creating {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;

                                case CrudAction.Read:
                                    // Read Method here. Input - Entity
                                    Console.WriteLine($"Reading {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;

                                case CrudAction.Update:
                                    // Update Method here. Input - Entity
                                    Console.WriteLine($"Updating {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;

                                case CrudAction.Delete:
                                    // Delete Method here. Input - Entity
                                    Console.WriteLine($"Deleting {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;
                            }
                            
                        }
                        break;
                    // Assign course schedule
                    case 2:
                        break;
                    // Register student into a course
                    case 3:
                        break;
                    // Student overview
                    case 4:
                        break;
                    // List active course and participating students
                    case 5:
                        break;
                    // Student ratio between passed and failed 
                    case 6:
                        break;
                    // Admin exits main menu
                    case 0:
                        return;
                    // Invalid input
                    default:
                        Console.WriteLine("\n Invalid input! Please enter a number between 0–9.\n");
                        continue;
                }
            }
        }
    }
}
