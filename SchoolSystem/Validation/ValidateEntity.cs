using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;

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


        public static Enrollment? ValidateDuplicateEnrollment(SchoolSystemContext context, bool updateBool, int enrollmentId)
        {
            {
                
                // Check duplicate EnrollmentId
                if (updateBool == false)
                {
                    if (context.Enrollments.Any(e => e.EnrollmentId == enrollmentId))
                    {
                        Console.WriteLine("An enrollment with this enrollment ID already exists. Returning to the CRUD menu");
                        return null;
                    }
                }

                Console.Write("Enter the ID of the student you want to reference: ");
                var studentId = int.Parse(Console.ReadLine());
                
                // Check StudentId exists
                if (!context.Students.Any(s => s.StudentId == studentId))
                {
                    Console.WriteLine("Invalid student ID. No student with this ID exists. Returning to the CRUD menu");
                    return null;
                }

                Console.Write("Enter the ID of the course you want to reference: ");
                var courseId = int.Parse(Console.ReadLine());

                // Check CourseId exists
                if (!context.Courses.Any(c => c.CourseId == courseId))
                {
                    Console.WriteLine("Invalid course ID. No course with this ID exists. Returning to the CRUD menu");
                    return null;
                }


                Console.Write("Enter new Enrollment date (yyyy-MM-dd hh:mm:ss): ");
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out DateTime enrollmentDate))
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
                    return null;
                }


                var updatedEnrollment = new Enrollment
                {
                    EnrollmentId = enrollmentId,
                    CourseId = courseId,
                    StudentId = studentId,
                    EnrollmentDate = enrollmentDate
                };
               
                return updatedEnrollment;
            }
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

        public static bool ValidateDuplicateGrade(SchoolSystemContext context, Grade grade)
        {
            // Check duplicate GradeId
            if (context.Grades.Any(g => g.GradeId == grade.GradeId))
            {
                Console.WriteLine("A grade with this grade ID already exists. Returning to the CRUD menu");
                return false;
            }

            // Check EnrollmentId exists
            if (!context.Enrollments.Any(e => e.EnrollmentId == grade.EnrollmentId))
            {
                Console.WriteLine("Invalid enrollment ID. No enrollment with this ID exists. Returning to the CRUD menu");
                return false;
            }

            // Check TeacherId exists
            if (!context.Teachers.Any(t => t.TeacherId == grade.TeacherId))
            {
                Console.WriteLine("Invalid teacher ID. No teacher with this ID exists. Returning to the CRUD menu");
                return false;
            }

            return true;
        }

        public static Enrollment? ValidateEnrollmentExists(SchoolSystemContext context, int id)
        {
            // Check EnrollmentId exists
            var enrollment = context.Enrollments.Find(id);

            if (enrollment == null)
            {
                Console.WriteLine("No enrollment with this ID exists. Returning to the CRUD menu");
                return null;
            }  
            return enrollment;
        }
    }
}
