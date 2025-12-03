using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAndActiveToCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // We leave this empty because we already ran the SQL manually in SSMS to satisfy the requirement for data first.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");
        }
    }
}
