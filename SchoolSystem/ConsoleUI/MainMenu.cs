using SchoolSystem.ConsoleUI;
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
        public ReportService ReportService { get; set; }
        public EnrollmentService EnrollmentService { get; set; }


        public MainMenu(StudentService studentService, ClassroomService classroomService, TeacherService teacherService, CourseService courseService, ReportService reportService, EnrollmentService enrollmentService)
        {
            StudentService = studentService;
            ClassroomService = classroomService;
            TeacherService = teacherService;
            CourseService = courseService;
            ReportService = reportService;
            EnrollmentService = enrollmentService;
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
                                        var student = MenuHelper.CreateStudent();
                                        StudentService.CreateStudent(student);
                                        Console.WriteLine($"Created student with ID: {student.StudentId}");
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        var classroom = MenuHelper.CreateClassroom();
                                        ClassroomService.CreateClasroom(classroom);
                                        Console.WriteLine($"Created classroom with ID: {classroom.ClassroomId}");
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        var teacher = MenuHelper.CreateTeacher();
                                        TeacherService.CreateTeacher(teacher);
                                        Console.WriteLine($"Created teacher with ID: {teacher.TeacherId}");
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        var course = MenuHelper.CreateCourse();
                                        CourseService.CreateCourse(course);
                                        Console.WriteLine($"Created course with ID: {course.CourseId}");
                                        
                                    }
                                    Console.ReadKey();
                                    break;

                                case CrudAction.Read:

                                    if (entity == EntityType.Student)
                                    {
                                        var students = StudentService.GetAllStudents();
                                        MenuHelper.PrintStudents(students);
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        var classrooms = ClassroomService.GetAllClassrooms();
                                        MenuHelper.PrintClassrooms(classrooms);
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        var teachers = TeacherService.GetAllTeachers();
                                        MenuHelper.PrintTeachers(teachers);
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        var courses = CourseService.GetAllCourses();
                                        MenuHelper.PrintCourses(courses);
                                    }
                                    Console.ReadKey();
                                    break;




                                case CrudAction.Update:
                                    // Update Method here. Input - Entity

                                    if (entity == EntityType.Student)
                                    {
                                        var student = MenuHelper.UpdateStudent();
                                        StudentService.UpdateStudent(student.StudentId, student);
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        var classroom = MenuHelper.UpdateClassroom();
                                        ClassroomService.UpdateClassroom(classroom.ClassroomId, classroom);
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        var teacher = MenuHelper.UpdateTeacher();
                                        TeacherService.UpdateTeacher(teacher.TeacherId,teacher);
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        var course = MenuHelper.UpdateCourse();
                                        CourseService.UpdateCourse(course.CourseId, course);
                                    }
                                    Console.WriteLine($"Updating {entity}...");
                                    Console.WriteLine("Press Enter to continue\n>");
                                    Console.ReadKey();
                                    break;

                                case CrudAction.Delete:
                                    if (entity == EntityType.Student)
                                    {
                                        MenuHelper.DeleteStudent(StudentService);
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        MenuHelper.DeleteClassroom(ClassroomService);
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        MenuHelper.DeleteTeacher(TeacherService);
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        MenuHelper.DeleteCourse(CourseService);
                                    }
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
                        Console.WriteLine("Enroll a student into a Course");
                        Console.Write("StudentId:");
                        var inputStudentId = Console.ReadLine();
                        Console.Write("CourseId:");
                        var inputCourseId = Console.ReadLine();

                        var enrollment = new Enrollment { CourseId = int.Parse(inputCourseId), StudentId = int.Parse(inputStudentId) };
                        EnrollmentService.CreateEnrollment(enrollment);
                        Console.WriteLine($"Enrolled student, enrollment id:{enrollment.EnrollmentId}");
                        Console.ReadKey();
                        break;
                    // Student overview
                    case 4:
                        break;
                    // List active course and participating students
                    case 5:
                        break;
                    // Student ratio between passed and failed 
                    case 6:
                        Console.Write("Enter start date: ");
                        var startDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter end date: ");
                        var endDate = DateTime.Parse(Console.ReadLine());
                        ReportService.PrintReport(startDate,endDate);
                        Console.WriteLine("Visa alla studenter med godkänt/ickeGodkänt");
                        Console.ReadKey();
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
