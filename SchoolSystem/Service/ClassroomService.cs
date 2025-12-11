using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;

namespace SchoolSystem.Service
{
    public class ClassroomService
    {
        public readonly SchoolSystemContext _context;

        public ClassroomService(SchoolSystemContext context)
        {
            _context = context;
        }

        public Classroom? CreateClasroom(Classroom classroom)
        {
            if (!ValidateEntity.ValidateDuplicateClassroom(_context, classroom))
            {
                return null;
            }
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return classroom;
        }
        public List<Classroom> GetAllClassrooms()
        {
            return _context.Classrooms.ToList();
        }
        public Classroom? GetClassroomById(int id)
        {
            return _context.Classrooms.Find(id);
        }
        public Classroom? UpdateClassroom(int id, Classroom updatedClassroom)
        {
            var classroom = _context.Classrooms.Find(id);

            if (classroom == null)
                return null;

            classroom.Name = updatedClassroom.Name;
            classroom.Capacity = updatedClassroom.Capacity;
            _context.SaveChanges();
            return classroom;
        }
        public bool DeleteClassroom(int id)
        {
            var classroom = _context.Classrooms.Find(id);

            if (classroom == null)
                return false;

            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            return true;
        }


    }

}

