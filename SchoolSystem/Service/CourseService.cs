using SchoolSystem.data;
using SchoolSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Service
{
    public class CourseService
    {
        public readonly SchoolContext _context;

        public CourseService(SchoolContext context)
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

            course.Schedule = updatedCourse.Schedule;
            course.CourseStartDate = updatedCourse.CourseStartDate;
            course.CourseEndDate = updatedCourse.CourseEndDate;
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
