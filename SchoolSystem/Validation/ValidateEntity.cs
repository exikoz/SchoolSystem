using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Service;

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
                return false;
            }
            return true;
        }


        public static EnrollmentInput? ValidateDuplicateEnrollment(SchoolSystemContext context, bool createBool, bool deleteBool)
        {

            int enrollmentId = 0;

            if (!createBool)
            {
                Console.WriteLine("Enter enrollment ID: ");

                // Check user input
                if (!int.TryParse(Console.ReadLine(), out enrollmentId))
                {
                    Console.WriteLine("Invalid input, please try again");
                    return null;
                }
                // Check if ID doesn't exist for Update & Delete options
                if (!context.Enrollments.Any(e => e.EnrollmentId == enrollmentId))
                {
                    Console.WriteLine("An enrollment with this enrollment ID doesn't exist. Returning to the CRUD menu");
                    return null;
                }
                // Check if delete CRUD option was selected and return
                if (deleteBool)
                {
                    return new EnrollmentInput { EnrollmentId = enrollmentId };
                }
            }
            // Check if enrollment ID already exists for Create option
            else
            {
                if (context.Enrollments.Any(e => e.EnrollmentId == enrollmentId))
                {
                    Console.WriteLine("An enrollment with this enrollment ID already exists. Returning to the CRUD menu");
                    return null;
                }
            }

            
            // If delete bool is false then we either Update or Create

            // Check if foreign keys do not exist
            Console.Write("Enter the ID of the student you want to reference: ");
            var studentId = int.Parse(Console.ReadLine());

            if (!context.Students.Any(s => s.StudentId == studentId))
            {
                Console.WriteLine("Invalid student ID. No student with this ID exists. Returning to the CRUD menu");
                return null;
            }

            Console.Write("Enter the ID of the course you want to reference: ");
            var courseId = int.Parse(Console.ReadLine());

            if (!context.Courses.Any(c => c.CourseId == courseId))
            {
                Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // User input DateTime validation
            Console.Write("Enter Enrollment date (yyyy-MM-dd hh:mm:ss): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime enrollmentDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
                return null;
            }

            return new EnrollmentInput
            {
                EnrollmentId = enrollmentId,
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = enrollmentDate
            };

        }

        public static bool ValidateDuplicateSchedule(SchoolSystemContext context, Schedule schedule)
        {
            // Check duplicate ScheduleId
            if (context.Schedules.Any(s => s.ScheduleId == schedule.ScheduleId))
            {
                Console.WriteLine("A schedule with this schedule ID already exists. Returning to the CRUD menu");
                return false;
            }

            // Check CourseId exists
            if (!context.Courses.Any(c => c.CourseId == schedule.CourseId))
            {
                Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                return false;
            }

            // Check TeacherId exists
            if (!context.Teachers.Any(t => t.TeacherId == schedule.TeacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                return false;
            }

            // Check ClassroomId exists
            if (!context.Classrooms.Any(c => c.ClassroomId == schedule.ClassroomId))
            {
                Console.WriteLine("Invalid classroom ID. No classroom with this ID exists. Returning to the CRUD menu");
                return false;
            }

            return true;
        }

        public static GradeInput? ValidateDuplicateGrade(SchoolSystemContext context, bool createBool, bool deleteBool)
        {

            int gradeId = 0;

            if (!createBool)
            {
                Console.Write("Enter grade ID: ");
                // Check user input
                if (!int.TryParse(Console.ReadLine(), out gradeId))
                {
                    Console.WriteLine("Invalid input, please try again");
                    return null;
                }
                // Check if ID doesn't exist for Update & Delete options
                if (!context.Grades.Any(g => g.GradeId == gradeId))
                {
                    Console.WriteLine("A grade with this ID does not exist. Returning to the CRUD menu");
                    return null;
                }

                // Check if delete CRUD option was selected and return
                if (deleteBool)
                {
                    return new GradeInput { GradeId = gradeId };
                }
            }
            else
            {
                // Check if enrollment ID already exists for Create option
                if (context.Grades.Any(g => g.GradeId == gradeId))
                {
                    Console.WriteLine("A grade with this ID already exists. Returning to the CRUD menu");
                    return null;
                }
            }

            // If delete bool is false then we either Update or Create

            // Check if foreign keys do not exist
            Console.Write("Enter the ID of the enrollment you want to reference: ");
            var enrollmentId = int.Parse(Console.ReadLine());

            if (!context.Enrollments.Any(e => e.EnrollmentId == enrollmentId))
            {
                Console.WriteLine("Invalid enrollment ID. No enrollment with this ID exists. Returning to the CRUD menu");
                return null;
            }

            Console.Write("Enter the ID of the teacher you want to reference: ");
            var teacherId = int.Parse(Console.ReadLine());

            if (!context.Teachers.Any(c => c.TeacherId == teacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // User input DateTime validation
            Console.Write("Enter Grade date (yyyy-MM-dd hh:mm:ss): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime gradeDate))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
                return null;
            }

            Console.Write("Enter Grade value A–F, optionally + or -, except for F: ");
            string gradeValue = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(gradeValue) || !System.Text.RegularExpressions.Regex.IsMatch(gradeValue, @"^[A-E][+-]?$|^F$"))
            {
                Console.WriteLine("Invalid grade format. Use A–E with optional + or -, or F without modifiers.");
                return null;

            }

            return new GradeInput
            {
                GradeId = gradeId,
                EnrollmentId = enrollmentId,
                TeacherId = teacherId,
                GradeValue = gradeValue,
                GradeDate = gradeDate
            };
        }
    }
}
