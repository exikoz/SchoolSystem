using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data
{
    public class DeleteDatabaseData()
    {
        private static SchoolSystemContext context => DatabaseProvider.Context;

        public static void DeleteAllData()
        {
            Console.WriteLine("Deleting all data...");

            context.Grades.RemoveRange(context.Grades);
            context.Enrollments.RemoveRange(context.Enrollments);
            context.Schedules.RemoveRange(context.Schedules);
            context.Courses.RemoveRange(context.Courses);
            context.Students.RemoveRange(context.Students);
            context.Teachers.RemoveRange(context.Teachers);
            context.Classrooms.RemoveRange(context.Classrooms);

            context.SaveChanges();

            Console.WriteLine("All data deleted successfully.");
        }
     }
}
