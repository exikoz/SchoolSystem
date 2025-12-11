using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class EnrollmentInput
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
    public class EnrollmentService
    {
        public bool createBool = false;
        public bool deleteBool = false;
        public readonly SchoolSystemContext _context;

        public EnrollmentService(SchoolSystemContext context)
        {
            _context = context;
        }

        public bool CreateEnrollment()
        {
            var enrollmentInput = ValidateEntity.ValidateDuplicateEnrollment(_context, createBool = true, deleteBool);
            if (enrollmentInput == null) 
            {
                return false;
            }
            var enrollment = new Enrollment
            {
                // EnrollmentId left as 0 → EF generates it
                StudentId = enrollmentInput.StudentId,
                CourseId = enrollmentInput.CourseId,
                EnrollmentDate = enrollmentInput.EnrollmentDate
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            Console.WriteLine($"Created enrollment with ID: {enrollment.EnrollmentId}");
            return true;
        }
        public List<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.ToList();
        }
        public Enrollment? GetEnrollmentById(int id)
        {
            return _context.Enrollments.Find(id);
        }
        public bool UpdateEnrollment()
        {
            // Validation
            var enrollmentInput = ValidateEntity.ValidateDuplicateEnrollment(_context, createBool, deleteBool);
            if (enrollmentInput == null)
            {
                return false;
            }

            // Loading the existing enrollment from the database
            var enrollment = _context.Enrollments.Find(enrollmentInput.EnrollmentId);


            enrollment.CourseId = enrollmentInput.CourseId;
            enrollment.StudentId = enrollmentInput.StudentId;
            enrollment.EnrollmentDate = enrollmentInput.EnrollmentDate;
            _context.SaveChanges();
            Console.WriteLine($"Updated enrollment with ID: {enrollment.EnrollmentId}");
            return true;
        }
        public bool DeleteEnrollment()
        {
            var enrollmentInput = ValidateEntity.ValidateDuplicateEnrollment(_context, createBool, deleteBool = true);

            if (enrollmentInput == null)
            {
                return false;
            }

            var enrollment = _context.Enrollments.Find(enrollmentInput.EnrollmentId);

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            Console.WriteLine($"Deleted enrollment with ID: {enrollment.EnrollmentId}");
            return true;
        }
    }
}
