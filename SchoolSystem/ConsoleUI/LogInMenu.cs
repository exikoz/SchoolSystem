using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Service;

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
                        using (var context = new SchoolSystemContext())
                        {
                            var menu = new MainMenu(new StudentService(context), new ClassroomService(context), new TeacherService(context), new CourseService(context), new ScheduleService(), new EnrollmentService(), new GradeService(), new MenuService(context), new ReportService(context));
                            menu.UseMainMenu();
                        }
                        break;

                    // Admin exits school system
                    case 0:
                        Console.WriteLine("\nThank you for using School System!");
                        return;
                    // Invalid input
                    default:
                        Console.WriteLine("\n Invalid input! Please select an option between 0–1.\n");
                        continue;
                }
            }
        }
    }
}
