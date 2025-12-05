using SchoolSystem.Models;
using SchoolSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    public class MainMenu
    {
        public StudentService StudentService { get; set; }
        public ClassroomService ClassroomService { get; set; }
        public TeacherService TeacherService { get; set; }
        public CourseService CourseService { get; set; }


        public MainMenu(StudentService studentService, ClassroomService classroomService, TeacherService teacherService, CourseService courseService)
        {
            StudentService = studentService;
            ClassroomService = classroomService;
            TeacherService = teacherService;
            CourseService = courseService;
        }

        public enum CrudAction
        {
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4
        };

        public enum EntityType
        {
            Student = 1,
            Classroom = 2,
            Teacher = 3,
            Course = 4,
        };

        public void UseMainMenu()
        {
            // Main menu options 
            List<string> menuOptions = new List<string>
            {
                "CRUD-operations",
                "Assign course schedule",
                "Register student into a course",
                "Student overview",
                "List active courses and participating students",
                "Student ratio between passed and failed"
            };

            // Crud menu options 
            List<string> crudMenuOptions = new List<string>
            {
                "Create",
                "Read",
                "Update",
                "Delete"
            };

            // Entity menu options
            List<string> entityMenuOptions = new List<string>
            {
                "Student",
                "Classroom",
                "Teacher",
                "Course"
            };


            while (true)
            {
                bool exitMenu = false;
                int? userInput = DisplayMenu.DisplayAndUseMenu(menuOptions, "Main menu", true);
                switch (userInput)
                {
                    // CRUD
                    case 1:
                        while (!exitMenu)
                        {
                            int? userCrudInput = DisplayMenu.DisplayAndUseMenu(crudMenuOptions, "Choose CRUD action", false);

                            if (userCrudInput == 0)
                            {
                                exitMenu = true;
                                break;
                            }

                            CrudAction action = (CrudAction)userCrudInput;

                            int? userEntityInput = DisplayMenu.DisplayAndUseMenu(entityMenuOptions, "Choose entity", false);
                            if (userEntityInput == null || userEntityInput == 0) continue;

                            EntityType entity = (EntityType)userEntityInput;

                            switch (action)
                            {
                                case CrudAction.Create:
                                    // Create Method here. Input - Entity

                                    if (entity == EntityType.Student)
                                    {
                                        Console.Write("Enter first name: ");
                                        var inputName = Console.ReadLine();
                                        Console.Write("Enter last name: ");
                                        var inputLastName = Console.ReadLine();
                                        Console.Write("Enter person number: ");
                                        var inputPersonNumber = Console.ReadLine();
                                        Console.Write("Enter valid email: ");
                                        var inputEmail = Console.ReadLine();

                                        var student = new Student { FirstName = inputName, LastName = inputLastName, PersonalNumber = inputPersonNumber, Email = inputEmail };
                                        StudentService.CreateStudent(student);
                                        Console.WriteLine($"Created student with ID: {student.StudentId}");
                                        Console.ReadKey();
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        Console.Write("Enter name for classroom: ");
                                        var inputClassRoomName = Console.ReadLine();
                                        Console.Write("Enter capacity: ");
                                        var inputCapacity = Console.ReadLine();

                                        var classroom = new Classroom { Name = inputClassRoomName, Capacity = int.Parse(inputCapacity) };
                                        ClassroomService.CreateClasroom(classroom);
                                        Console.WriteLine($"Created classroom with ID: {classroom.ClassroomId}");
                                        Console.ReadKey();
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        Console.Write("Enter first name: ");
                                        var inputName = Console.ReadLine();
                                        Console.Write("Enter last name: ");
                                        var inputLastName = Console.ReadLine();
                                        Console.Write("Enter valid email: ");
                                        var inputEmail = Console.ReadLine();

                                        var teacher = new Teacher { FirstName = inputName, LastName = inputLastName, Email = inputEmail };
                                        TeacherService.CreateTeacher(teacher);
                                        Console.WriteLine($"Created teacher with ID: {teacher.TeacherId}");
                                        Console.ReadKey();

                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        Console.Write("Enter name of the course: ");
                                        var courseName = Console.ReadLine();
                                        Console.Write("Enter start date: ");
                                        var startDate = DateTime.Parse(Console.ReadLine());
                                        Console.Write("Enter end date: ");
                                        var endDate = DateTime.Parse(Console.ReadLine());

                                        var course = new Course { Name = courseName, StartDate = startDate, EndDate = endDate };
                                        CourseService.CreateCourse(course);
                                        Console.WriteLine($"Created course with ID: {course.CourseId}");
                                        Console.ReadKey();
                                    }
                                    break;

                                case CrudAction.Read:

                                    if (entity == EntityType.Student)
                                    {
                                        var students = StudentService.GetAllStudents();
                                        foreach (var student in students)
                                        {
                                            Console.WriteLine($"Id: {student.StudentId} \nName: {student.FirstName} {student.LastName} \nEmail: {student.Email}\nPerson number: {student.PersonalNumber}");
                                            Console.WriteLine();
                                        }
                                        Console.ReadKey();

                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        var classrooms = ClassroomService.GetAllClassrooms();

                                        foreach (var classroom in classrooms)
                                        {
                                            Console.WriteLine($"Id: {classroom.ClassroomId} \nName: {classroom.Name}\nCapacity: {classroom.Capacity}");
                                            Console.WriteLine();


                                        }
                                        Console.ReadKey();
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        var teachers = TeacherService.GetAllTeachers();
                                        foreach (var teacher in teachers)
                                        {
                                            Console.WriteLine($"Id: {teacher.TeacherId} \nName: {teacher.FirstName} {teacher.LastName} \nEmail: {teacher.Email}");
                                            Console.WriteLine();
                                        }
                                        Console.ReadKey();
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        var courses = CourseService.GetAllCourses();
                                        foreach (var course in courses)
                                        {
                                            Console.WriteLine($"Id: {course.CourseId}\nName: {course.Name}\nstart: {course.StartDate:d}\nEnd: {course.EndDate:d}");
                                            Console.WriteLine();
                                        }
                                        Console.ReadKey();
                                    }
                                     break;


                                     

                                case CrudAction.Update:
                                    // Update Method here. Input - Entity
                                    Console.WriteLine($"Updating {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;

                                case CrudAction.Delete:
                                    // Delete Method here. Input - Entity
                                    Console.WriteLine($"Deleting {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadLine();
                                    break;
                            }

                        }
                        break;
                    // Assign course schedule
                    case 2:
                        break;
                    // Register student into a course
                    case 3:
                        break;
                    // Student overview
                    case 4:
                        break;
                    // List active course and participating students
                    case 5:
                        break;
                    // Student ratio between passed and failed 
                    case 6:
                        break;
                    // Admin exits main menu
                    case 0:
                        return;
                    // Invalid input
                    default:
                        Console.WriteLine("\n Invalid input! Please enter a number between 0–9.\n");
                        continue;
                }
            }
        }
    }
}
