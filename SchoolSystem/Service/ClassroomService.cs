using SchoolSystem.data;
using SchoolSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{
    public class ClassroomService
    {
        public readonly SchoolContext _context;

        public ClassroomService(SchoolContext context)
        {
            _context = context;
        }

        public Classroom CreateClasroom(Classroom classroom)
        {
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

