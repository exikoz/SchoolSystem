using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class GradeInput
    {
        public int GradeId { get; set; } 
        public int EnrollmentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime GradeDate { get; set; }
        public string GradeValue { get; set; } = string.Empty;
    }

        public class GradeService
    {
        public bool createBool = false;
        public bool deleteBool = false;
        public readonly SchoolSystemContext _context;

        public GradeService(SchoolSystemContext context)
        {
            _context = context;
        }

        public bool CreateGrade()
        {
            var gradeInput = ValidateEntity.ValidateDuplicateGrade(_context, createBool = true, deleteBool);
            if (gradeInput == null)
            {
                return false;
            }

            var grade = new Grade
            {
                EnrollmentId = gradeInput.EnrollmentId,
                TeacherId = gradeInput.TeacherId,
                GradeValue = gradeInput.GradeValue,
                GradeDate = gradeInput.GradeDate
            };

            _context.Grades.Add(grade);
            _context.SaveChanges();
            Console.WriteLine($"Created grade with ID: {grade.GradeId}");
            return true;
        }
        public List<Grade> GetAllGrades()
        {
            return _context.Grades.ToList();
        }
        public Grade? GetGradeById(int id)
        {
            return _context.Grades.Find(id);
        }
        public bool UpdateGrade()
        {
            // Validation
            var gradeInput = ValidateEntity.ValidateDuplicateGrade(_context, createBool, deleteBool);
            if (gradeInput == null)
            {
                return false;
            }

            // Loading the existing grade from the database
            var grade = _context.Grades.Find(gradeInput.GradeId);

            grade.EnrollmentId = gradeInput.EnrollmentId;
            grade.TeacherId = gradeInput.TeacherId;
            grade.GradeValue = gradeInput.GradeValue;
            grade.GradeDate = gradeInput.GradeDate;

            _context.SaveChanges();
            Console.WriteLine($"Updated grade with ID: {grade.GradeId}");
            return true;



        }
        public bool DeleteGrade()
        {
            var gradeInput = ValidateEntity.ValidateDuplicateGrade(_context, createBool, deleteBool = true);

            if (gradeInput == null)
            {
                return false;
            }
            
            var grade = _context.Grades.Find(gradeInput.GradeId);

            _context.Grades.Remove(grade);
            _context.SaveChanges();
            Console.WriteLine($"Deleted grade with ID: {grade.GradeId}");
            return true;
        }


    }
}
