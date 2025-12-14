using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using System;
using System.Linq;

namespace SchoolSystem.Service
{
    public class ReportService
    {
        private readonly SchoolSystemContext _context;

        public ReportService(SchoolSystemContext context)
        {
            _context = context;
        }

        // SQL View
        public void ShowGradeViewReport()
        {
            Console.WriteLine("--- REPORT FROM SQL VIEW ---");
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var report = _context.StudentGradeViews
                                     .Where(v => v.StudentId == studentId)
                                     .ToList();

                foreach (var row in report)
                {
                    Console.WriteLine($"{row.CourseName}: {row.GradeValue} (Set by: {row.TeacherName})");
                }
            }
        }

        // Stored Procedure
        public void ShowGradeStatisticsProc()
        {
            Console.WriteLine("--- STATISTICS FROM STORED PROCEDURE ---");
            // Set hardcoded date for test, or ask for input
            var start = DateTime.Now.AddYears(-1);
            var end = DateTime.Now.AddYears(1);

            var stats = _context.Database
                                .SqlQueryRaw<GradeStatistic>("EXEC GetGradeDistribution {0}, {1}", start, end)
                                .ToList();

            foreach (var s in stats)
            {
                Console.WriteLine($"Grade {s.GradeValue}: {s.Count} count");
            }
        }

        // LINQ GroupBy
        public void ShowGradeDistributionLinq()
        {
            Console.WriteLine("--- STATISTICS FROM LINQ (GROUP BY) ---");
            var start = DateTime.Now.AddYears(-5); 
            var end = DateTime.Now.AddYears(1);

            var stats = _context.Grades
                .Where(g => g.GradeDate >= start && g.GradeDate <= end)
                .GroupBy(g => g.GradeValue)
                .Select(g => new
                {
                    Grade = g.Key,
                    Count = g.Count()
                })
                .ToList();

            foreach (var s in stats)
            {
                Console.WriteLine($"Grade {s.Grade}: {s.Count} count");
            }
        }
    }
}
