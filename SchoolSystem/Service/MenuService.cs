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
    }
}
