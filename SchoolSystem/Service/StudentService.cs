using Microsoft.EntityFrameworkCore;
using SchoolSystem.data;
using SchoolSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{

    public class StudentService
    {
        private readonly SchoolContext _context;

        public StudentService(SchoolContext context)
        {
            _context = context;
        }

        public Student CreateStudent(Student student)
        {
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

            student.FullName = updatedStudent.FullName;
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



