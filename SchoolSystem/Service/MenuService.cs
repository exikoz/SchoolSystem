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
            Console.WriteLine("Enter student id:");
            int WhatStudentId = int.Parse(Console.ReadLine());
            // Gets enrollment, courses and student

            var StudentOverviewInDatabase = _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefault(s => s.StudentId == WhatStudentId);

            if (StudentOverviewInDatabase != null)
            {
                Console.WriteLine("Student overview:");
                Console.WriteLine($"Name: {StudentOverviewInDatabase.FirstName} {StudentOverviewInDatabase.LastName}");
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
            Console.Write("Enter start date: ");
            var start = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date: ");
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
            Console.ReadKey();
        }
        public void ShowActiveCoursesWithStudents()
        {
            DateTime today = DateTime.Today;

            var activeCourses = _context.Courses.Where(c => c.StartDate <= today && c.EndDate >= today).Include(c => c.Enrollments).ThenInclude(e => e.Student).ToList();

            if (!activeCourses.Any())
            {
                Console.WriteLine("No active courses at the moment.");
                return;
            }

            Console.WriteLine("Active courses and participating students:");

            foreach (var course in activeCourses)
            {
                Console.WriteLine($"Course: {course.Name}");
                Console.WriteLine($"Period: {course.StartDate:dd-MM-yyyy} → {course.EndDate:dd-MM-yyyy}");

                var enrolledStudents = course.Enrollments.Select(e => e.Student).ToList();
                if (enrolledStudents.Any())
                {
                    foreach (var student in enrolledStudents)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} ({student.Email})");
                    }
                }
                else
                {
                    Console.WriteLine("No students enrolled."); 
                }
            }
        }
        public void ShowStudentGradeOverview()
        {
            Console.Write("Enter student ID:");
            int studentId = int.Parse(Console.ReadLine());

            var studentGradeOverview = _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Grades).ThenInclude(g => g.Teacher)
                .Include(s => s.Enrollments).ThenInclude(e => e.Course).ToList();

            if (!studentGradeOverview.Any())
            {
                Console.WriteLine("This student does not exist in the database.");
                return;
            }

            foreach (var student in studentGradeOverview)
            {
                Console.WriteLine($"Student {student.FirstName}, {student.LastName}, {student.Email} ");
                Console.WriteLine("Courses and grades:");
                //SelectMany takes grades from all courses which the student is enrolled in
                var allGrades = student.Enrollments.SelectMany(e => e.Grades).ToList();

                if (!allGrades.Any())
                {
                    Console.WriteLine("This student does not have any grades yet.");
                }
                else
                {
                    foreach (var grade in allGrades)
                    {
                        Console.WriteLine($"Course: {grade.Enrollment.Course.Name}");
                        Console.WriteLine($"Grade: {grade.GradeValue}");
                        Console.WriteLine($"Teacher: {grade.Teacher.FirstName} {grade.Teacher.LastName}");
                        Console.WriteLine($"Date: {grade.GradeDate}");
                    }
                }
            }
        }
    }
}
