using SchoolSystem.Data;
using SchoolSystem.Models;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Service;

namespace SchoolSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test att vi kan skapa contexten
            using (var context = new SchoolSystemContext())
            {
                // Detta skapar databasen om den inte finns (när migrationer är klara)
                // context.Database.EnsureCreated(); 
                Console.WriteLine("Context skapad och namespaces fungerar!");

                var menu = new MainMenu(new StudentService(context), new ClassroomService(context), new TeacherService(context), new CourseService(context));
                menu.UseMainMenu();

            }

        }
    }
}
