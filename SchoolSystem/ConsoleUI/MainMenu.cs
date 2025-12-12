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
        public ScheduleService ScheduleService { get; set; }
        public EnrollmentService EnrollmentService { get; set; }
        public GradeService GradeService { get; set; }


        public MainMenu(StudentService studentService, ClassroomService classroomService, TeacherService teacherService, CourseService courseService, ScheduleService scheduleService, EnrollmentService enrollmentService, GradeService gradeService)
        {
            StudentService = studentService;
            ClassroomService = classroomService;
            TeacherService = teacherService;
            CourseService = courseService;
            ScheduleService = scheduleService;
            EnrollmentService = enrollmentService;
            GradeService = gradeService;
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
            Schedule = 5,
            Enrollment = 6,
            Grade = 7
        };

        public void UseMainMenu()
        {
            // Main menu options 
            List<string> menuOptions = new List<string>
            {
                "CRUD-operations",
                "Assign course schedule", //Maybe Delete
                "Register student into a course", //Maybe Delete
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
                "Course",
                "Schedule (Requires Course, Teacher, Classroom)",
                "Enrollment (Requires Course, Student)",
                "Grade (Requires Enrollment, Teacher)"
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
                                        if (StudentService.CreateStudent(student) == null)
                                        {
                                            break;
                                        }
                                        Console.WriteLine($"Created student with ID: {student.StudentId}");
                                    }
                                    else if (entity == EntityType.Classroom)
                                    {
                                        var classroom = MenuHelper.CreateClassroom();
                                        if (ClassroomService.CreateClasroom(classroom) == null)
                                        {
                                            break;
                                        }
                                        Console.WriteLine($"Created classroom with ID: {classroom.ClassroomId}");
                                    }
                                    else if (entity == EntityType.Teacher)
                                    {
                                        var teacher = MenuHelper.CreateTeacher();
                                        if (TeacherService.CreateTeacher(teacher) == null)
                                        {
                                            break;
                                        }
                                        Console.WriteLine($"Created teacher with ID: {teacher.TeacherId}");
                                    }
                                    else if (entity == EntityType.Course)
                                    {
                                        var course = MenuHelper.CreateCourse();
                                        if (CourseService.CreateCourse(course) == null)
                                        {
                                            break;
                                        }
                                        Console.WriteLine($"Created course with ID: {course.CourseId}");
                                        
                                    }
                                    else if (entity == EntityType.Schedule)
                                    {
                                        ScheduleService.CreateSchedule();
                                    }
                                    else if (entity == EntityType.Enrollment)
                                    {
                                        EnrollmentService.CreateEnrollment();
                                    }
                                    else if (entity == EntityType.Grade)
                                    {
                                        GradeService.CreateGrade();
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
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
                                    else if (entity == EntityType.Schedule)
                                    {
                                        var schedule = ScheduleService.GetAllSchedules();
                                        MenuHelper.PrintSchedule(schedule);

                                    }
                                    else if (entity == EntityType.Enrollment)
                                    {
                                        var enrollment = EnrollmentService.GetAllEnrollments();
                                        MenuHelper.PrintEnrollment(enrollment);

                                    }
                                    else if (entity == EntityType.Grade)
                                    {
                                        var grade = GradeService.GetAllGrades();
                                        MenuHelper.PrintGrade(grade);
                                    }
                                    Console.WriteLine("Press Enter to continue\n>");
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
                                    else if (entity == EntityType.Schedule)
                                    {
                                        ScheduleService.UpdateSchedule();
                                    }
                                    else if (entity == EntityType.Enrollment)
                                    {
                                        EnrollmentService.UpdateEnrollment();
                                    }
                                    else if (entity == EntityType.Grade)
                                    {
                                        GradeService.UpdateGrade();
                                    }
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
                                    else if (entity == EntityType.Schedule)
                                    {
                                        ScheduleService.DeleteSchedule();
                                    }
                                    else if (entity == EntityType.Enrollment)
                                    {
                                        EnrollmentService.DeleteEnrollment();
                                    }
                                    else if (entity == EntityType.Grade)
                                    {
                                        GradeService.DeleteGrade();
                                    }
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
                        Console.WriteLine("\n Invalid input! Please an option between 0–6.\n");
                        continue;
                }
            }
        }
    }
}
