using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddReportFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // not needed as we did it data first alread
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "CreatedDate",
            //    table: "Teachers",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "StartTime",
            //    table: "Schedules",
            //    type: "datetime2",
            //    nullable: false,
            //    oldClrType: typeof(TimeOnly),
            //    oldType: "time");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "EndTime",
            //    table: "Schedules",
            //    type: "datetime2",
            //    nullable: false,
            //    oldClrType: typeof(TimeOnly),
            //    oldType: "time");

            // create view
            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW View_StudentGradeDetails AS
                SELECT 
                    s.StudentId,
                    s.FirstName,
                    s.LastName,
                    s.PersonalNumber,
                    c.Name AS CourseName,
                    g.GradeValue,
                    g.GradeDate,
                    t.FirstName + ' ' + t.LastName AS TeacherName
                FROM Students s
                JOIN Enrollments e ON s.StudentId = e.StudentId
                JOIN Courses c ON e.CourseId = c.CourseId
                LEFT JOIN Grades g ON e.EnrollmentId = g.EnrollmentId
                LEFT JOIN Teachers t ON g.TeacherId = t.TeacherId
                WHERE g.GradeValue IS NOT NULL
            ");

            // create procedure
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetGradeDistribution
                    @StartDate DATETIME2,
                    @EndDate DATETIME2
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT GradeValue, COUNT(*) AS Count
                    FROM Grades
                    WHERE GradeDate BETWEEN @StartDate AND @EndDate
                    GROUP BY GradeValue
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Teachers");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTime",
                table: "Schedules",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetGradeDistribution");
            migrationBuilder.Sql("DROP VIEW IF EXISTS View_StudentGradeDetails");
        }
    }
}
