using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Data;

namespace SchoolSystem.Validation
{
    public class ValidateEntity
    {
        public static bool ValidateDuplicateStudent(SchoolSystemContext context, Student student)
        {
            // Check duplicate StudentId
            if (context.Students.Any(s => s.StudentId == student.StudentId))
            {
                Console.WriteLine("A student with this student ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateTeacher(SchoolSystemContext context, Teacher teacher)
        {
            // Check duplicate TeacherId
            if (context.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
            {
                Console.WriteLine("A teacher with this teacher ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateClassroom(SchoolSystemContext context, Classroom classroom)
        {
            // Check duplicate ClassroomId
            if (context.Classrooms.Any(s => s.ClassroomId == classroom.ClassroomId))
            {
                Console.WriteLine("A classroom with this classroom ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateCourse(SchoolSystemContext context, Course course)
        {
            // Check duplicate CourseId
            if (context.Courses.Any(s => s.CourseId == course.CourseId))
            {
                Console.WriteLine("A course with this course ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateEnrollment(SchoolSystemContext context, Enrollment enrollment)
        {
            {
                // Check duplicate EnrollmentId
                if (context.Enrollments.Any(e => e.EnrollmentId == enrollment.EnrollmentId))
                {
                    Console.WriteLine("An enrollment with this enrollment ID already exists. Returning to the CRUD menu");
                    Console.WriteLine("Press Enter to continue\n>");
                    Console.ReadLine();
                    return false;
                }

                // Check StudentId exists
                if (!context.Students.Any(s => s.StudentId == enrollment.StudentId))
                {
                    Console.WriteLine("Invalid student ID. No student with this ID exists. Returning to the CRUD menu");
                    Console.WriteLine("Press Enter to continue\n>");
                    Console.ReadLine();
                    return false;
                }

                // Check CourseId exists
                if (!context.Courses.Any(c => c.CourseId == enrollment.CourseId))
                {
                    Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                    Console.WriteLine("Press Enter to continue\n>");
                    Console.ReadLine();
                    return false;
                }

                return true;
            }
        }

        public static bool ValidateDuplicateSchedule(SchoolSystemContext context, Schedule schedule)
        {
            // Check duplicate ScheduleId
            if (context.Schedules.Any(s => s.ScheduleId == schedule.ScheduleId))
            {
                Console.WriteLine("A schedule with this schedule ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            // Check CourseId exists
            if (!context.Courses.Any(c => c.CourseId == schedule.CourseId))
            {
                Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            // Check TeacherId exists
            if (!context.Teachers.Any(t => t.TeacherId == schedule.TeacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            // Check ClassroomId exists
            if (!context.Classrooms.Any(c => c.ClassroomId == schedule.ClassroomId))
            {
                Console.WriteLine("Invalid classroom ID. No classroom with this ID exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            return true;
        }

        public static bool ValidateDuplicateGrade(SchoolSystemContext context, Grade grade)
        {
            // Check duplicate GradeId
            if (context.Grades.Any(g => g.GradeId == grade.GradeId))
            {
                Console.WriteLine("A grade with this grade ID already exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            // Check EnrollmentId exists
            if (!context.Enrollments.Any(e => e.EnrollmentId == grade.EnrollmentId))
            {
                Console.WriteLine("Invalid enrollment ID. No enrollment with this ID exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            // Check TeacherId exists
            if (!context.Teachers.Any(t => t.TeacherId == grade.TeacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                Console.WriteLine("Press Enter to continue\n>");
                Console.ReadLine();
                return false;
            }

            return true;
        }
    }
}
