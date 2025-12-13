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
            using (var context = new SchoolSystemContext())
            {
                // creates db if it's not there (after migrating)
                // context.Database.EnsureCreated(); 

                var menu = new MainMenu(
                    new StudentService(context),
                    new ClassroomService(context),
                    new TeacherService(context),
                    new CourseService(context),
                    new ScheduleService(),
                    new EnrollmentService(),
                    new GradeService(),
                    new MenuService(context),
                    new ReportService(context));

                menu.UseMainMenu();

            }

        }
    }
}
