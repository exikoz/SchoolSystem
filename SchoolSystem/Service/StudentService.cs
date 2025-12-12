using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{

    public class StudentService
    {
        private readonly SchoolSystemContext _context;

        public StudentService(SchoolSystemContext context)
        {
            _context = context;
        }

        public Student? CreateStudent(Student student)
        {
            if (!ValidateEntity.ValidateDuplicateStudent(_context, student))
            {
                return null;
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }
        public Student? UpdateStudent(int id, Student updatedStudent)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return null;

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Email = updatedStudent.Email;
            student.PersonalNumber = updatedStudent.PersonalNumber;
            _context.SaveChanges();
            return student;
        }
        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return false;

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }


    }

}



