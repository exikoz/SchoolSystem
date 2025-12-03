using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixScheduleRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScheduleClassrooms_FkClassroomTeacherId",
                table: "ScheduleClassrooms",
                column: "FkClassroomTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleClassrooms_ClassroomTeachers_FkClassroomTeacherId",
                table: "ScheduleClassrooms",
                column: "FkClassroomTeacherId",
                principalTable: "ClassroomTeachers",
                principalColumn: "ClassroomTeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleClassrooms_ClassroomTeachers_FkClassroomTeacherId",
                table: "ScheduleClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleClassrooms_FkClassroomTeacherId",
                table: "ScheduleClassrooms");
        }
    }
}
