using SchoolSystem.data;
using SchoolSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{
    public class TeacherService
    {
        private readonly SchoolContext _context;

        public TeacherService(SchoolContext context)
        {
            _context = context;

        }
        public Teacher CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }
        public Teacher? GetTeacherById(int id)
        {
            return _context.Teachers.Find(id);
        }
        public Teacher? UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
                return null;

            teacher.FullName = updatedTeacher.FullName;
            teacher.TeachingSubject = updatedTeacher.TeachingSubject;
            _context.SaveChanges();
            return teacher;
        }
        public bool DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true;
        }
    }
}