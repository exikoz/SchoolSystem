using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.ConsoleUI;
using SchoolSystem.Models;
using SchoolSystem.Service;
using SchoolSystem.Data;

namespace SchoolSystem.Service
{
    public class MenuService
    {
        private readonly SchoolSystemContext _context;

        public MenuService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void ShowStudentOverview()
        {
            Console.WriteLine("Enter Student id:");
            int studentId = int.Parse(Console.ReadLine());
            Console.Clear();
            // Gets enrollment, courses and student

            var StudentOverviewInDatabase = _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefault(s => s.StudentId == studentId);

            if (StudentOverviewInDatabase != null)
            {
                Console.WriteLine("Student Overview:\n");
                Console.WriteLine($"Name: {StudentOverviewInDatabase.FirstName} {StudentOverviewInDatabase.LastName}");
                Console.WriteLine($"Student ID: {studentId}");
                Console.WriteLine($"SSN: {StudentOverviewInDatabase.PersonalNumber}");
                Console.WriteLine($"Email: {StudentOverviewInDatabase.Email}");
                Console.WriteLine("Courses:");
                if (StudentOverviewInDatabase.Enrollments.Any())
                {
                    foreach (var enrollment in StudentOverviewInDatabase.Enrollments)
                    {
                        Console.WriteLine($"{enrollment.Course.Name} ");
                    }
                }
                else
                {
                    Console.WriteLine("No courses enrolled.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void PrintReport()
        {
            Console.Write("Enter start date (yyyy-MM-dd): ");
            var start = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date (yyyy-MM-dd): ");
            var end = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            var grades = _context.Grades
                .Include(g => g.Enrollment)//also include the enrollment
                .ThenInclude(g => g.Course)//also include the course
                .Include(g => g.Enrollment)
                .ThenInclude(e => e.Student)// also include the student
                .Where(g => g.GradeDate > start && g.GradeDate < end)
                .ToList();

            var notPassed = 0;
            var passed = 0;

            foreach (var g in grades)
            {
                if (g.GradeValue == "F")
                {
                    notPassed++;
                }
                else
                {
                    passed++;
                }
                Console.WriteLine($"Name: {g.Enrollment.Student.FirstName} {g.Enrollment.Student.FirstName}");
                Console.WriteLine($"Course: {g.Enrollment.Course.Name}");
                Console.WriteLine($"Grade: {g.GradeValue}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Passed: {passed} - Not passed: {notPassed}");
        }
        public void ShowActiveCoursesWithStudents()
        {
            Console.Write("Enter start date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("Invalid start date format.");
                return;
            }

            Console.Write("Enter end date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("Invalid end date format.");
                return;
            }

            if (endDate < startDate)
            {
                Console.WriteLine("End date cannot be earlier than start date.");
                return;
            }

            var activeCourses = _context.Courses
                .Where(c =>
                    c.StartDate <= endDate && 
                    c.EndDate >= startDate      
                )
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .ToList();

            if (!activeCourses.Any())
            {
                Console.WriteLine("No courses active within this date interval.");
                return;
            }

            Console.WriteLine("\nCourses active in the selected interval and participating students:");

            foreach (var course in activeCourses)
            {
                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine($"Period: {course.StartDate:dd-MM-yyyy} - {course.EndDate:dd-MM-yyyy}");

                var enrolledStudents = course.Enrollments.Select(e => e.Student).ToList();

                if (!enrolledStudents.Any())
                {
                    Console.WriteLine("No students enrolled.");
                }
                else
                {
                    foreach (var student in enrolledStudents)
                    {
                        Console.WriteLine($"Student ID {student.StudentId} - {student.FirstName} {student.LastName} ({student.Email})");
                    }
                }

                Console.WriteLine();
            }
        }
        public void ShowStudentGradeOverview()
        {
            Console.Write("Enter student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Clear();

            var student = _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Grades)
                        .ThenInclude(g => g.Teacher)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                Console.WriteLine("This student does not exist in the database.");
                return;
            }

            Console.WriteLine($"Student: {student.FirstName} {student.LastName}, {student.Email}");
            Console.WriteLine("Courses and grades:\n");

            var allGrades = student.Enrollments.SelectMany(e => e.Grades).ToList();

            if (!allGrades.Any())
            {
                Console.WriteLine("This student does not have any grades yet.");
                return;
            }

            foreach (var grade in allGrades)
            {
                Console.WriteLine($"StudentId: {studentId}");
                Console.WriteLine($"Course: {grade.Enrollment.Course.Name}");
                Console.WriteLine($"Grade: {grade.GradeValue}");
                Console.WriteLine($"Grade issued by: {grade.Teacher.FirstName} {grade.Teacher.LastName}");
                Console.WriteLine($"Grade issued at: {grade.GradeDate}");
                Console.WriteLine();
            }
        }
    }
}
