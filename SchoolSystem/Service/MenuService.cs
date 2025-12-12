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
                        Console.WriteLine($" {enrollment.Course.Name} ");
                    }
                }
                else
                {
                    Console.WriteLine(" - No courses enrolled.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
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
    }
}
