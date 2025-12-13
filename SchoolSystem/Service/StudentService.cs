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

        public void CreateStudent(Student student)
        {
            if (!ValidateEntity.ValidateDuplicateStudent(_context, student))
            {
                return;
            }
            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created student with ID: {student.StudentId}");
            return;
        }
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }
        public void UpdateStudent(int id, Student updatedStudent)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                Console.WriteLine("A student with this student ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            _context.SaveChanges();
            Console.WriteLine($"Successfully updated student with ID: {id}");
            return;
        }
        public void DeleteStudent()
        {
            Console.WriteLine("Enter the ID of the student you want to delete: ");
            
            // Check user input
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input, Returning to the CRUD menu");
                return;
            }
            var student = _context.Students.Find(id);

            if (student == null)
            {
                Console.WriteLine("A student with this student ID doesn't exist. Returning to the CRUD menu");
                return;
            }
                
            _context.Students.Remove(student);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted student with ID: {student.StudentId}");
            return;
        }
    }
}



