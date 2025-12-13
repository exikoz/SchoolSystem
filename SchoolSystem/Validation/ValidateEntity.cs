using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
            // Check duplicate StudentId, Personal number and Email for Create CRUD option
            if (context.Students.Any(s => s.StudentId == student.StudentId))
            {
                Console.WriteLine("\nA student with this student ID already exists. Returning to the CRUD menu");
                return false;
            }
            if (context.Students.Any(s => s.PersonalNumber == student.PersonalNumber))
            {
                Console.WriteLine("\nA student with this SSN already exists. Returning to the CRUD menu");
                return false;
            }
            if (context.Students.Any(s => s.Email == student.Email))
            {
                Console.WriteLine("\nA student with this email already exists. Returning to the CRUD menu");
                return false;
            }
            return true;
        }

        public static bool ValidateDuplicateTeacher(SchoolSystemContext context, Teacher teacher)
        {
            // Check duplicate TeacherId
            if (context.Teachers.Any(t => t.TeacherId == teacher.TeacherId))
            {
                Console.WriteLine("\nA teacher with this teacher ID already exists. Returning to the CRUD menu");
                return false;
            }
            // Check duplicate Email
            if (context.Teachers.Any(t => t.Email == teacher.Email))
            {
                Console.WriteLine("\nA teacher with this email already exists. Returning to the CRUD menu");
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateClassroom(SchoolSystemContext context, Classroom classroom)
        {
            // Check duplicate ClassroomId
            if (context.Classrooms.Any(s => s.ClassroomId == classroom.ClassroomId))
            {
                Console.WriteLine("\nA classroom with this classroom ID already exists. Returning to the CRUD menu");
                return false;
            }
            // Check duplicate Name
            if (context.Classrooms.Any(s => s.Name == classroom.Name))
            {
                Console.WriteLine("\nA classroom with this name already exists. Returning to the CRUD menu");
                return false;
            }
            return true;
        }
        public static bool ValidateDuplicateCourse(SchoolSystemContext context, Course course)
        {
            // Check duplicate CourseId
            if (context.Courses.Any(s => s.CourseId == course.CourseId))
            {
                Console.WriteLine("\nA course with this course ID already exists. Returning to the CRUD menu");
                return false;
            }
            // Check duplicate Name
            if (context.Courses.Any(s => s.CourseId == course.CourseId))
            {
                Console.WriteLine("\nA course with this name already exists. Returning to the CRUD menu");
                return false;
            }
            return true;
        }


        public static EnrollmentInput? ValidateEnrollment(SchoolSystemContext context, bool createBool, bool deleteBool)
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


            // If delete bool is false then we check if foreign keys do not exist for either Update or Create options

            // Student FK
            Console.Write("Enter the ID of the student you want to reference: ");
            var studentId = int.Parse(Console.ReadLine());

            if (!context.Students.Any(s => s.StudentId == studentId))
            {
                Console.WriteLine("Invalid student ID. No student with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // Course FK
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

        public static ScheduleInput? ValidateSchedule(SchoolSystemContext context, bool createBool, bool deleteBool)
        {
            int scheduleId = 0;

            if (!createBool)
            {
                Console.Write("Enter schedule ID: ");

                // Check user input
                if (!int.TryParse(Console.ReadLine(), out scheduleId))
                {
                    Console.WriteLine("Invalid input, please try again");
                    return null;
                }

                // Check if ID doesn't exist for Update & Delete options
                if (!context.Schedules.Any(s => s.ScheduleId == scheduleId))
                {
                    Console.WriteLine("A schedule with this ID does not exist. Returning to the CRUD menu");
                    return null;
                }

                // Check if delete CRUD option was selected and return
                if (deleteBool)
                {
                    return new ScheduleInput { ScheduleId = scheduleId };
                }
            }
            else
            {
                // Check if schedule ID already exists for Create option
                if (context.Schedules.Any(s => s.ScheduleId == scheduleId))
                {
                    Console.WriteLine("A schedule with this ID already exists. Returning to the CRUD menu");
                    return null;
                }
            }

            // If delete bool is false then we check if foreign keys do not exist for either Update or Create options

            // Course FK
            Console.Write("Enter the ID of the course you want to reference: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId) ||
                !context.Courses.Any(c => c.CourseId == courseId))
            {
                Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // Teacher FK
            Console.Write("Enter the ID of the teacher you want to reference: ");
            if (!int.TryParse(Console.ReadLine(), out int teacherId) ||
                !context.Teachers.Any(t => t.TeacherId == teacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // Classroom FK
            Console.Write("Enter the ID of the classroom you want to reference: ");
            if (!int.TryParse(Console.ReadLine(), out int classroomId) ||
                !context.Classrooms.Any(r => r.ClassroomId == classroomId))
            {
                Console.WriteLine("Invalid classroom ID. No classroom with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // Start time
            Console.Write("Enter Start time (yyyy-MM-dd HH:mm:ss): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startTime))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
                return null;
            }

            // End time
            Console.Write("Enter End time (yyyy-MM-dd HH:mm:ss): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endTime))
            {
                Console.WriteLine("Invalid date format. Please enter a valid date.");
                return null;
            }

            // Ensures that end time is after start time
            if (endTime <= startTime)
            {
                Console.WriteLine("End time must be after start time.");
                return null;
            }

            return new ScheduleInput
            {
                ScheduleId = scheduleId,
                CourseId = courseId,
                TeacherId = teacherId,
                ClassroomId = classroomId,
                StartTime = startTime,
                EndTime = endTime
            };
        }

        public static GradeInput? ValidateGrade(SchoolSystemContext context, bool createBool, bool deleteBool)
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

            // If delete bool is false then we check if foreign keys do not exist for either Update or Create options

            // Enrollment FK
            Console.Write("Enter the ID of the enrollment you want to reference: ");
            var enrollmentId = int.Parse(Console.ReadLine());

            if (!context.Enrollments.Any(e => e.EnrollmentId == enrollmentId))
            {
                Console.WriteLine("Invalid enrollment ID. No enrollment with this ID exists. Returning to the CRUD menu");
                return null;
            }

            // Teacher FK
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

            // User input Grade validation
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
