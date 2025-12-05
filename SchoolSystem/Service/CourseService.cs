using SchoolSystem.Data;
using SchoolSystem.Models;


namespace SchoolSystem.Service
{
    public class CourseService
    {
        public readonly SchoolSystemContext _context;

        public CourseService(SchoolSystemContext context)
        {
            _context = context;
        }

        public Course CreateCourse (Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;

        }
        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
        public Course? GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }
        public Course? UpdateCourse(int id, Course updatedCourse)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return null;

            course.Name= updatedCourse.Name;
            course.StartDate = updatedCourse.StartDate;
            course.EndDate = updatedCourse.EndDate;
            _context.SaveChanges();
            return course;
        }
        public bool DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
                return false;

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;
        }


    }
}
