using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorCourseDemo.Migrations
{
    public partial class CourseModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Credits",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "Course");
        }
    }
}
