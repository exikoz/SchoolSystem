using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{


    public static class DataSeeder
    {
        private static SchoolSystemContext context => DatabaseProvider.Context;

        public static bool Seed()
        {

            // Check if the database already contains data
            var populatedTable = GetPopulatedTables(context);

            // Check seed eligibility
            var check = CheckSeedEligibility(context, populatedTable);
            if (!check)
            {
                return false;
            }
            // If empty we insert data into the database
            else
            {
                // Students
                context.Students.AddRange(
                    new Student { FirstName = "Alice", LastName = "Andersson", Email = "alice.andersson@example.com", PersonalNumber = "20010101-1234" },
                    new Student { FirstName = "Bob", LastName = "Berg", Email = "bob.berg@example.com", PersonalNumber = "19991212-5678" },
                    new Student { FirstName = "Clara", LastName = "Carlsson", Email = "clara.carlsson@example.com", PersonalNumber = "20020303-9876" },
                    new Student { FirstName = "David", LastName = "Dahl", Email = "david.dahl@example.com", PersonalNumber = "20000404-1111" },
                    new Student { FirstName = "Emma", LastName = "Ekström", Email = "emma.ekstrom@example.com", PersonalNumber = "20030505-2222" }
                );
                context.SaveChanges();


                // Teachers
                context.Teachers.AddRange(
                    new Teacher { FirstName = "Daniel", LastName = "Dahl", Email = "daniel.dahl@example.com" },
                    new Teacher { FirstName = "Eva", LastName = "Ekström", Email = "eva.ekstrom@example.com" },
                    new Teacher { FirstName = "Fredrik", LastName = "Franzén", Email = "fredrik.franzen@example.com" },
                    new Teacher { FirstName = "Greta", LastName = "Gustavsson", Email = "greta.gustavsson@example.com" },
                    new Teacher { FirstName = "Hugo", LastName = "Holm", Email = "hugo.holm@example.com" }
                );
                context.SaveChanges();

                // Courses
                context.Courses.AddRange(
                    new Course { Name = "Mathematics", StartDate = new DateTime(2025, 1, 13), EndDate = new DateTime(2025, 3, 7) },
                    new Course { Name = "Programming Basics", StartDate = new DateTime(2025, 2, 3), EndDate = new DateTime(2025, 4, 25) },
                    new Course { Name = "English Literature", StartDate = new DateTime(2025, 3, 10), EndDate = new DateTime(2025, 5, 30) },
                    new Course { Name = "Physics Fundamentals", StartDate = new DateTime(2025, 4, 7), EndDate = new DateTime(2025, 6, 27) },
                    new Course { Name = "Database Design", StartDate = new DateTime(2025, 5, 5), EndDate = new DateTime(2025, 7, 25) }
                );
                context.SaveChanges();

                // Classrooms
                context.Classrooms.AddRange(
                    new Classroom { Name = "Zoom 1", Capacity = 30 },
                    new Classroom { Name = "Zoom 2", Capacity = 25 },
                    new Classroom { Name = "Zoom 3", Capacity = 20 },
                    new Classroom { Name = "Zoom 4", Capacity = 35 },
                    new Classroom { Name = "Zoom 5", Capacity = 40 }
                );
                context.SaveChanges();

                // Schedules
                context.Schedules.AddRange(
                    new Schedule
                    {
                        CourseId = context.Courses.First().CourseId,
                        TeacherId = context.Teachers.First().TeacherId,
                        ClassroomId = context.Classrooms.First().ClassroomId,
                        StartTime = DateTime.Now.AddDays(1).AddHours(9),
                        EndTime = DateTime.Now.AddDays(1).AddHours(11)
                    },
                    new Schedule
                    {
                        CourseId = context.Courses.Skip(1).First().CourseId,
                        TeacherId = context.Teachers.Skip(1).First().TeacherId,
                        ClassroomId = context.Classrooms.Skip(1).First().ClassroomId,
                        StartTime = DateTime.Now.AddDays(2).AddHours(13),
                        EndTime = DateTime.Now.AddDays(2).AddHours(15)
                    },
                    new Schedule
                    {
                        CourseId = context.Courses.Skip(2).First().CourseId,
                        TeacherId = context.Teachers.Skip(2).First().TeacherId,
                        ClassroomId = context.Classrooms.Skip(2).First().ClassroomId,
                        StartTime = DateTime.Now.AddDays(3).AddHours(10),
                        EndTime = DateTime.Now.AddDays(3).AddHours(12)
                    },
                    new Schedule
                    {
                        CourseId = context.Courses.Skip(3).First().CourseId,
                        TeacherId = context.Teachers.Skip(3).First().TeacherId,
                        ClassroomId = context.Classrooms.Skip(3).First().ClassroomId,
                        StartTime = DateTime.Now.AddDays(4).AddHours(8),
                        EndTime = DateTime.Now.AddDays(4).AddHours(10)
                    },
                    new Schedule
                    {
                        CourseId = context.Courses.Skip(4).First().CourseId,
                        TeacherId = context.Teachers.Skip(4).First().TeacherId,
                        ClassroomId = context.Classrooms.Skip(4).First().ClassroomId,
                        StartTime = DateTime.Now.AddDays(5).AddHours(14),
                        EndTime = DateTime.Now.AddDays(5).AddHours(16)
                    }
                );
                context.SaveChanges();

                // Enrollments
                context.Enrollments.AddRange(
                    new Enrollment
                    {
                        StudentId = context.Students.First().StudentId,
                        CourseId = context.Courses.First().CourseId,
                        EnrollmentDate = DateTime.Now.AddDays(-30)
                    },
                    new Enrollment
                    {
                        StudentId = context.Students.Skip(1).First().StudentId,
                        CourseId = context.Courses.Skip(1).First().CourseId,
                        EnrollmentDate = DateTime.Now.AddDays(-25)
                    },
                    new Enrollment
                    {
                        StudentId = context.Students.Skip(2).First().StudentId,
                        CourseId = context.Courses.Skip(2).First().CourseId,
                        EnrollmentDate = DateTime.Now.AddDays(-20)
                    },
                    new Enrollment
                    {
                        StudentId = context.Students.Skip(3).First().StudentId,
                        CourseId = context.Courses.Skip(3).First().CourseId,
                        EnrollmentDate = DateTime.Now.AddDays(-15)
                    },
                    new Enrollment
                    {
                        StudentId = context.Students.Skip(4).First().StudentId,
                        CourseId = context.Courses.Skip(4).First().CourseId,
                        EnrollmentDate = DateTime.Now.AddDays(-10)
                    }
                );
                context.SaveChanges();

                // Grades
                context.Grades.AddRange(
                    new Grade
                    {
                        EnrollmentId = context.Enrollments.First().EnrollmentId,
                        TeacherId = context.Teachers.First().TeacherId,
                        GradeValue = "A",
                        GradeDate = DateTime.Now.AddDays(-5)
                    },
                    new Grade
                    {
                        EnrollmentId = context.Enrollments.Skip(1).First().EnrollmentId,
                        TeacherId = context.Teachers.Skip(1).First().TeacherId,
                        GradeValue = "B+",
                        GradeDate = DateTime.Now.AddDays(-4)
                    },
                    new Grade
                    {
                        EnrollmentId = context.Enrollments.Skip(2).First().EnrollmentId,
                        TeacherId = context.Teachers.Skip(2).First().TeacherId,
                        GradeValue = "C-",
                        GradeDate = DateTime.Now.AddDays(-3)
                    },
                    new Grade
                    {
                        EnrollmentId = context.Enrollments.Skip(3).First().EnrollmentId,
                        TeacherId = context.Teachers.Skip(3).First().TeacherId,
                        GradeValue = "A-",
                        GradeDate = DateTime.Now.AddDays(-2)
                    },
                    new Grade
                    {
                        EnrollmentId = context.Enrollments.Skip(4).First().EnrollmentId,
                        TeacherId = context.Teachers.Skip(4).First().TeacherId,
                        GradeValue = "F",
                        GradeDate = DateTime.Now.AddDays(-1)
                    }
                );
                context.SaveChanges();
                Console.WriteLine("Database seeded successfully.");
                return true;
            }
        }

        // Method that checks if seeding is possible.
        public static bool CheckSeedEligibility(SchoolSystemContext context, List<string> populatedTable)
        {
            // Ensure database exists by creating it first
            // context.Database.EnsureCreated();

            // 1. Ensure that the database is empty
            if (populatedTable.Count > 0)
            {
                Console.WriteLine("These tables already contain data and prevent the program from completing the seeding process.");
                foreach (var table in populatedTable)
                {
                    Console.WriteLine($"{table}");
                }
                return false;
            }

            // 2. Ensure that all primary keys are on zero (Auto-fix logic)
            var entities = PrimaryKeyChecker.GetEntitiesWithNonNullIdentity(context);

            if (entities.Any())
            {
                // If tables are empty (passed step 1) but have dirty identities (step 2), reset them.
                foreach (var entity in entities)
                {
                    context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT ('{entity}', RESEED, 0)");
                }
            }

            return true;
        }

        // Method that return a list of tables that already contains data
        public static List<string> GetPopulatedTables(SchoolSystemContext context)
        {
            var populated = new List<string>();

            if (context.Students.Any())
                populated.Add("Students");

            if (context.Teachers.Any())
                populated.Add("Teachers");

            if (context.Courses.Any())
                populated.Add("Courses");

            if (context.Classrooms.Any())
                populated.Add("Classrooms");

            if (context.Schedules.Any())
                populated.Add("Schedules");

            if (context.Enrollments.Any())
                populated.Add("Enrollments");

            if (context.Grades.Any())
                populated.Add("Grades");

            return populated;
        }

        public static class PrimaryKeyChecker
        {
            public static List<string> GetEntitiesWithNonNullIdentity(SchoolSystemContext context)
            {
                var result = new List<string>();

                if (HasNonNullIdentity("Students", context)) result.Add("Students");
                if (HasNonNullIdentity("Teachers", context)) result.Add("Teachers");
                if (HasNonNullIdentity("Courses", context)) result.Add("Courses");
                if (HasNonNullIdentity("Classrooms", context)) result.Add("Classrooms");
                if (HasNonNullIdentity("Schedules", context)) result.Add("Schedules");
                if (HasNonNullIdentity("Enrollments", context)) result.Add("Enrollments");
                if (HasNonNullIdentity("Grades", context)) result.Add("Grades");

                return result;
            }

            private static bool HasNonNullIdentity(string tableName, SchoolSystemContext context)
            {
                var sql = $"SELECT IDENT_CURRENT('[dbo].[{tableName}]')";
                decimal? identityValue = context.Database
                    .SqlQueryRaw<decimal?>($"{sql}")
                    .AsEnumerable()
                    .FirstOrDefault();

                // If identityValue is not NULL/zero then the associated table has had inserts before
                return identityValue != null && identityValue != 0;
            }
        }
    }
}
