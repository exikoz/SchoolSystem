using SchoolSystem.Data;
using SchoolSystem.Models;


namespace SchoolSystem.Service
{
    public class TeacherService
    {
        private readonly SchoolSystemContext _context;

        public TeacherService(SchoolSystemContext context)
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

            teacher.FirstName = updatedTeacher.FirstName;
            teacher.LastName = updatedTeacher.LastName;
            teacher.TeacherEmail = updatedTeacher.TeacherEmail;
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