using SchoolSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{
    public class ReportService
    {
        public readonly SchoolSystemContext _context;

        public ReportService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void PrintReport(DateTime start, DateTime end)
        {
           var grades = _context.Grades.Where(g => g.GradeDate > start && g.GradeDate < end).ToList();

            var notPassed = 0;
            var passed = 0;

            

            foreach(var g in grades)
            {
                if (g.GradeValue == "g")
                {
                    passed++;
                }
                else
                {
                    notPassed ++;
                }
            }
            Console.WriteLine($"Passed: {passed} - Not passed: {notPassed}");
        }
    }
}

