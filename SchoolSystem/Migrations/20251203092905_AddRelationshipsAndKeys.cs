using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipsAndKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherReportId",
                table: "TeacherSignatures");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSignatures_FkReportId",
                table: "TeacherSignatures",
                column: "FkReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSignatures_FkTeacherId",
                table: "TeacherSignatures",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_FkReportId",
                table: "StudentReports",
                column: "FkReportId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_FkStudentId",
                table: "StudentReports",
                column: "FkStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_FkCourseId",
                table: "Enrolls",
                column: "FkCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_FkStudentId",
                table: "Enrolls",
                column: "FkStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeachers_FkClassroomId",
                table: "ClassroomTeachers",
                column: "FkClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeachers_FkTeacherId",
                table: "ClassroomTeachers",
                column: "FkTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Assgineds_FkClassroomId",
                table: "Assgineds",
                column: "FkClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Assgineds_FkStudentId",
                table: "Assgineds",
                column: "FkStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assgineds_Classrooms_FkClassroomId",
                table: "Assgineds",
                column: "FkClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assgineds_Students_FkStudentId",
                table: "Assgineds",
                column: "FkStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Classrooms_FkClassroomId",
                table: "ClassroomTeachers",
                column: "FkClassroomId",
                principalTable: "Classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassroomTeachers_Teachers_FkTeacherId",
                table: "ClassroomTeachers",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_FkCourseId",
                table: "Enrolls",
                column: "FkCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Students_FkStudentId",
                table: "Enrolls",
                column: "FkStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_Reports_FkReportId",
                table: "StudentReports",
                column: "FkReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_Students_FkStudentId",
                table: "StudentReports",
                column: "FkStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSignatures_Reports_FkReportId",
                table: "TeacherSignatures",
                column: "FkReportId",
                principalTable: "Reports",
                principalColumn: "ReportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSignatures_Teachers_FkTeacherId",
                table: "TeacherSignatures",
                column: "FkTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assgineds_Classrooms_FkClassroomId",
                table: "Assgineds");

            migrationBuilder.DropForeignKey(
                name: "FK_Assgineds_Students_FkStudentId",
                table: "Assgineds");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Classrooms_FkClassroomId",
                table: "ClassroomTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassroomTeachers_Teachers_FkTeacherId",
                table: "ClassroomTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_FkCourseId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Students_FkStudentId",
                table: "Enrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_Reports_FkReportId",
                table: "StudentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_Students_FkStudentId",
                table: "StudentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSignatures_Reports_FkReportId",
                table: "TeacherSignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSignatures_Teachers_FkTeacherId",
                table: "TeacherSignatures");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSignatures_FkReportId",
                table: "TeacherSignatures");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSignatures_FkTeacherId",
                table: "TeacherSignatures");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_FkReportId",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_FkStudentId",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_FkCourseId",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_FkStudentId",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomTeachers_FkClassroomId",
                table: "ClassroomTeachers");

            migrationBuilder.DropIndex(
                name: "IX_ClassroomTeachers_FkTeacherId",
                table: "ClassroomTeachers");

            migrationBuilder.DropIndex(
                name: "IX_Assgineds_FkClassroomId",
                table: "Assgineds");

            migrationBuilder.DropIndex(
                name: "IX_Assgineds_FkStudentId",
                table: "Assgineds");

            migrationBuilder.AddColumn<int>(
                name: "TeacherReportId",
                table: "TeacherSignatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
