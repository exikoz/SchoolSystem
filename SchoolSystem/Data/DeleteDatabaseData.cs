using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            // Reset identity for all tables
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Schedules', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Teachers', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Students', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Classrooms', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Courses', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Grades', RESEED, 0)");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Enrollments', RESEED, 0)");

            Console.WriteLine("All data deleted successfully.");
        }
     }
}
