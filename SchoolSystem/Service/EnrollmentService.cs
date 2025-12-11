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
    public class EnrollmentService
    {
        public bool updateBool = false;
        public readonly SchoolSystemContext _context;

        public EnrollmentService(SchoolSystemContext context)
        {
            _context = context;
        }

        public Enrollment? CreateEnrollment(Enrollment enrollment)
        {
            if (ValidateEntity.ValidateDuplicateEnrollment(_context, updateBool, enrollment.EnrollmentId) == null) 
            {
                return null;
            }
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return enrollment;
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
            Console.Write("Enter Enrollment ID to update: ");
            var enrollmentId = int.Parse(Console.ReadLine());

            var enrollment = ValidateEntity.ValidateEnrollmentExists(_context, enrollmentId);
            if (enrollment == null)
            {
                return false;
            }

            var updatedEnrollment = ValidateEntity.ValidateDuplicateEnrollment(_context, updateBool = true, enrollmentId);
            if (updatedEnrollment == null)
            {
                return false;
            }

            enrollment.CourseId = updatedEnrollment.CourseId;
            enrollment.StudentId = updatedEnrollment.StudentId;
            enrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
            _context.SaveChanges();
            return true;
        }
        public bool DeleteEnrollment(int id)
        {
            var enrollment = ValidateEntity.ValidateEnrollmentExists(_context, id);
            
            if (enrollment == null)
            {
                return false;
            }

            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return true;
        }


    }
}
