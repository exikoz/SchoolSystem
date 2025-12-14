using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class TeacherService
    {
        private readonly SchoolSystemContext _context;

        public TeacherService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void CreateTeacher(Teacher teacher)
        {
            if (!ValidateEntity.ValidateDuplicateTeacher(_context, teacher))
            {
                return;
            }

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created teacher with ID: {teacher.TeacherId}");
            return;
        }

        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public Teacher? GetTeacherById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                Console.WriteLine("A teacher with this teacher ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            teacher.FirstName = updatedTeacher.FirstName;
            teacher.LastName = updatedTeacher.LastName;

            _context.SaveChanges();
            Console.WriteLine($"Successfully updated teacher with ID: {id}");
            return;
        }

        public void DeleteTeacher()
        {
            Console.WriteLine("Enter the ID of the teacher you want to delete: ");

            // Validate input
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Returning to the CRUD menu");
                return;
            }

            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                Console.WriteLine("A teacher with this teacher ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted teacher with ID: {teacher.TeacherId}");
            return;
        }
    }
}
