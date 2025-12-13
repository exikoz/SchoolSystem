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
            Console.WriteLine("--- RAPPORT FRÅN SQL VIEW ---");
            Console.Write("Ange Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var report = _context.StudentGradeViews
                                     .Where(v => v.StudentId == studentId)
                                     .ToList();

                foreach (var row in report)
                {
                    Console.WriteLine($"{row.CourseName}: {row.GradeValue} (Satt av: {row.TeacherName})");
                }
            }
        }

        // Stored Procedure
        public void ShowGradeStatisticsProc()
        {
            Console.WriteLine("--- STATISTIK FRÅN STORED PROCEDURE ---");
            // Sätt datum hårtkodat för test, eller be om input
            var start = DateTime.Now.AddYears(-1);
            var end = DateTime.Now.AddYears(1);

            var stats = _context.Database
                                .SqlQueryRaw<GradeStatistic>("EXEC GetGradeDistribution {0}, {1}", start, end)
                                .ToList();

            foreach (var s in stats)
            {
                Console.WriteLine($"Betyg {s.GradeValue}: {s.Count} stycken");
            }
        }
    }
}
