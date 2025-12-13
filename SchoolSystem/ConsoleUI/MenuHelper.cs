using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.Service;
using SchoolSystem.Validation;

namespace SchoolSystem.ConsoleUI
{
    public class MenuHelper
    {

        public static Student CreateStudent()
        {
            Console.Write("Enter first name: ");
            var inputName = Console.ReadLine();
            Console.Write("Enter last name: ");
            var inputLastName = Console.ReadLine();
            Console.Write("Enter person number: ");
            var inputPersonNumber = Console.ReadLine();
            Console.Write("Enter valid email: ");
            var inputEmail = Console.ReadLine();


            return new Student { FirstName = inputName, LastName = inputLastName, PersonalNumber = inputPersonNumber, Email = inputEmail };


        }
        public static Classroom CreateClassroom()
        {
            Console.Write("Enter name for classroom: ");
            var inputClassRoomName = Console.ReadLine();
            Console.Write("Enter capacity: ");
            var inputCapacity = Console.ReadLine();

            return new Classroom { Name = inputClassRoomName, Capacity = int.Parse(inputCapacity) };


        }
        public static Teacher CreateTeacher()
        {
            Console.Write("Enter first name: ");
            var inputName = Console.ReadLine();
            Console.Write("Enter last name: ");
            var inputLastName = Console.ReadLine();
            Console.Write("Enter valid email: ");
            var inputEmail = Console.ReadLine();

            return new Teacher { FirstName = inputName, LastName = inputLastName, Email = inputEmail };

        }
        public static Course CreateCourse()
        {
            Console.Write("Enter name of the course: ");
            var courseName = Console.ReadLine();
            Console.Write("Enter start date: ");
            var startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date: ");
            var endDate = DateTime.Parse(Console.ReadLine());

            return new Course { Name = courseName, StartDate = startDate, EndDate = endDate };
        }

 
        public static void PrintStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.StudentId} \nName: {student.FirstName} {student.LastName} \nEmail: {student.Email}\nPerson number: {student.PersonalNumber}");
                Console.WriteLine();
            }
        }
        public static void PrintClassrooms(List<Classroom> classrooms)
        {
            foreach (var classroom in classrooms)
            {
                Console.WriteLine($"Id: {classroom.ClassroomId} \nName: {classroom.Name}\nCapacity: {classroom.Capacity}");
                Console.WriteLine();


            }
        }
        public static void PrintTeachers(List<Teacher> teachers)
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Id: {teacher.TeacherId} \nName: {teacher.FirstName} {teacher.LastName} \nEmail: {teacher.Email}");
                Console.WriteLine();
            }
        }
        public static void PrintCourses(List<Course> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"Id: {course.CourseId}\nName: {course.Name}\nstart: {course.StartDate:d}\nEnd: {course.EndDate:d}");
                Console.WriteLine();
            }
        }

        public static void PrintSchedule(List<Schedule> schedules)
        {
            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Id: {schedule.ScheduleId} \nTime Interval: {schedule.StartTime} - {schedule.EndTime}");
                Console.WriteLine();
            }
        }

        public static void PrintEnrollment(List<Enrollment> enrollments)
        {
            foreach (var enrollment in enrollments)
            {
                Console.WriteLine($"Id: {enrollment.EnrollmentId} \nEnrollment date: {enrollment.EnrollmentDate}");
                Console.WriteLine();
            }
        }

        public static void PrintGrade(List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                Console.WriteLine($"Id: {grade.GradeId} \nGrade date: {grade.GradeDate}");
                Console.WriteLine();
            }
        }

        public static Student UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Enter new first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Enter new last name: ");
            var lastName = Console.ReadLine();

            return new Student
            {
                StudentId = id,   
                FirstName = firstName,
                LastName = lastName,
            };
        }
        public static Classroom UpdateClassroom()
        {
            Console.Write("Enter Classroom ID to update: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Enter new capacity: ");
            var capacity = int.Parse(Console.ReadLine());

            return new Classroom
            {
                ClassroomId = id,
                Capacity = capacity
            };
        }
        public static Teacher UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Enter new first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Enter new last name: ");
            var lastName = Console.ReadLine();

            return new Teacher
            {
                TeacherId = id,
                FirstName = firstName,
                LastName = lastName,
            };
        }
        public static Course UpdateCourse()
        {
            Console.Write("Enter Course ID to update: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Enter new start date: ");
            var startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter new end date: ");
            var endDate = DateTime.Parse(Console.ReadLine());

            return new Course
            {
                CourseId = id,
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
