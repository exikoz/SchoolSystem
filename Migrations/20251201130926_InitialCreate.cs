using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assgineds",
                columns: table => new
                {
                    AssignedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkStudentId = table.Column<int>(type: "int", nullable: false),
                    FkClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assgineds", x => x.AssignedId);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomTeachers",
                columns: table => new
                {
                    ClassroomTeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false),
                    FkClassroomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomTeachers", x => x.ClassroomTeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Enrolls",
                columns: table => new
                {
                    EnrollsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkCourseId = table.Column<int>(type: "int", nullable: false),
                    FkStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolls", x => x.EnrollsId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeInterval = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleClassrooms",
                columns: table => new
                {
                    ScheduleClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkClassroomTeacherId = table.Column<int>(type: "int", nullable: false),
                    TimeInterval = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleClassrooms", x => x.ScheduleClassroomId);
                });

            migrationBuilder.CreateTable(
                name: "StudentReports",
                columns: table => new
                {
                    StudentReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkReportId = table.Column<int>(type: "int", nullable: false),
                    FkStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentReports", x => x.StudentReportId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeachingSubject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSignatures",
                columns: table => new
                {
                    TeacherSignatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherReportId = table.Column<int>(type: "int", nullable: false),
                    FkReportId = table.Column<int>(type: "int", nullable: false),
                    FkTeacherId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSignatures", x => x.TeacherSignatureId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assgineds");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "ClassroomTeachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Enrolls");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ScheduleClassrooms");

            migrationBuilder.DropTable(
                name: "StudentReports");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherSignatures");
        }
    }
}
