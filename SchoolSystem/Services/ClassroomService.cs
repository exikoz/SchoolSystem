using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class ClassroomService
    {
        private readonly SchoolSystemContext _context;

        public ClassroomService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void CreateClassroom(Classroom classroom)
        {
            if (!ValidateEntity.ValidateDuplicateClassroom(_context, classroom))
            {
                return;
            }

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created classroom with ID: {classroom.ClassroomId}");
            return;
        }

        public List<Classroom> GetAllClassrooms()
        {
            return _context.Classrooms.ToList();
        }

        public Classroom? GetClassroomById(int id)
        {
            return _context.Classrooms.Find(id);
        }

        public void UpdateClassroom(int id, Classroom updatedClassroom)
        {
            var classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                Console.WriteLine("A classroom with this classroom ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            classroom.Capacity = updatedClassroom.Capacity;

            _context.SaveChanges();
            Console.WriteLine($"Successfully updated classroom with ID: {id}");
            return;
        }

        public void DeleteClassroom()
        {
            Console.WriteLine("Enter the ID of the classroom you want to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Returning to the CRUD menu");
                return;
            }

            var classroom = _context.Classrooms.Find(id);

            if (classroom == null)
            {
                Console.WriteLine("A classroom with this classroom ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted classroom with ID: {classroom.ClassroomId}");
            return;
        }
    }
}

