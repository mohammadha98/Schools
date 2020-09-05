using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Fix_TeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolTeachers_Users_UserId",
                table: "SchoolTeachers");

            migrationBuilder.DropIndex(
                name: "IX_SchoolTeachers_UserId",
                table: "SchoolTeachers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SchoolTeachers");

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "SchoolTeachers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "SchoolTeachers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "SchoolTeachers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "SchoolTeachers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SchoolTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeachers_UserId",
                table: "SchoolTeachers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolTeachers_Users_UserId",
                table: "SchoolTeachers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
