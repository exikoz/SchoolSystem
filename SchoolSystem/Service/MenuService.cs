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

            var studentOverviewInDatabase = _context.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefault(s => s.StudentId == WhatStudentId);

            if (studentOverviewInDatabase != null)
            {
                Console.WriteLine("Student overview:");
                Console.WriteLine($"Name: {studentOverviewInDatabase.FirstName} {studentOverviewInDatabase.LastName}");
                Console.WriteLine($"SSN: {studentOverviewInDatabase.PersonalNumber}");
                Console.WriteLine($"Email: {studentOverviewInDatabase.Email}");
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
    }
}
