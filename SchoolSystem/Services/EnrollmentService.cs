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
    // Creating a class where user input data will be stored and then used for either Create and Update an entity.
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
        private static SchoolSystemContext _context => DatabaseProvider.Context;

        public void CreateEnrollment()
        {
            var enrollmentInput = ValidateEntity.ValidateEnrollment(_context, createBool = true, deleteBool);
            if (enrollmentInput == null) 
            {
                return;
            }
            var enrollment = new Enrollment
            {
                StudentId = enrollmentInput.StudentId,
                CourseId = enrollmentInput.CourseId,
                EnrollmentDate = enrollmentInput.EnrollmentDate
            };
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created enrollment with ID: {enrollment.EnrollmentId}");
        }
        public List<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.ToList();
        }
        public Enrollment? GetEnrollmentById(int id)
        {
            return _context.Enrollments.Find(id);
        }
        public void UpdateEnrollment()
        {
            // Validation
            var enrollmentInput = ValidateEntity.ValidateEnrollment(_context, createBool, deleteBool);
            if (enrollmentInput == null)
            {
                return;
            }

            // Loading the existing enrollment from the database
            var enrollment = _context.Enrollments.Find(enrollmentInput.EnrollmentId);


            enrollment.CourseId = enrollmentInput.CourseId;
            enrollment.StudentId = enrollmentInput.StudentId;
            enrollment.EnrollmentDate = enrollmentInput.EnrollmentDate;
            _context.SaveChanges();
            Console.WriteLine($"Successfully updated enrollment with ID: {enrollment.EnrollmentId}");
        }
        public void DeleteEnrollment()
        {
            var enrollmentInput = ValidateEntity.ValidateEnrollment(_context, createBool, deleteBool = true);

            if (enrollmentInput == null)
            {
                return;
            }

            var enrollment = _context.Enrollments.Find(enrollmentInput.EnrollmentId);

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted enrollment with ID: {enrollment.EnrollmentId}");
        }
    }
}
