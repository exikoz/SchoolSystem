using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Validation;


namespace SchoolSystem.Service
{
    public class CourseService
    {
        private readonly SchoolSystemContext _context;

        public CourseService(SchoolSystemContext context)
        {
            _context = context;
        }

        public void CreateCourse(Course course)
        {
            if (!ValidateEntity.ValidateDuplicateCourse(_context, course))
            {
                return;
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
            Console.WriteLine($"Successfully created course with ID: {course.CourseId}");
            return;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void UpdateCourse(int id, Course updatedCourse)
        {
            var course = _context.Courses.Find(id);

            if (course == null)
            {
                Console.WriteLine("A course with this course ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            course.StartDate = updatedCourse.StartDate;
            course.EndDate = updatedCourse.EndDate;

            _context.SaveChanges();
            Console.WriteLine($"Successfully updated course with ID: {id}");
            return;
        }

        public void DeleteCourse()
        {
            Console.WriteLine("Enter the ID of the course you want to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Returning to the CRUD menu");
                return;
            }

            var course = _context.Courses.Find(id);

            if (course == null)
            {
                Console.WriteLine("A course with this course ID doesn't exist. Returning to the CRUD menu");
                return;
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            Console.WriteLine($"Successfully deleted course with ID: {course.CourseId}");
            return;
        }
    }
}