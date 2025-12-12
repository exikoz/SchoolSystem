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
    // Creating a class where user input data will be stored and then used for either Create and Update an entity.
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

        public void CreateGrade()
        {
            var gradeInput = ValidateEntity.ValidateGrade(_context, createBool = true, deleteBool);
            if (gradeInput == null)
            {
                return;
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
            Console.WriteLine($"Successfully created grade with ID: {grade.GradeId}");
        }
        public List<Grade> GetAllGrades()
        {
            return _context.Grades.ToList();
        }
        public Grade? GetGradeById(int id)
        {
            return _context.Grades.Find(id);
        }
        public void UpdateGrade()
        {
            // Validation
            var gradeInput = ValidateEntity.ValidateGrade(_context, createBool, deleteBool);
            if (gradeInput == null)
            {
                return;
            }

            // Loading the existing grade from the database
            var grade = _context.Grades.Find(gradeInput.GradeId);

            grade.EnrollmentId = gradeInput.EnrollmentId;
            grade.TeacherId = gradeInput.TeacherId;
            grade.GradeValue = gradeInput.GradeValue;
            grade.GradeDate = gradeInput.GradeDate;

            _context.SaveChanges();
            Console.WriteLine($"Successfully updated grade with ID: {grade.GradeId}");
        }

        public void DeleteGrade()
        {
            var gradeInput = ValidateEntity.ValidateGrade(_context, createBool, deleteBool = true);

            if (gradeInput == null)
            {
                return;
            }
            
            var grade = _context.Grades.Find(gradeInput.GradeId);

            _context.Grades.Remove(grade);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted grade with ID: {grade.GradeId}");
        }
    }
}
