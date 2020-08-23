using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class editblogComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "BlogComments",
                maxLength: 700,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminRead",
                table: "BlogComments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "IsAdminRead",
                table: "BlogComments");

            migrationBuilder.AddColumn<int>(
                name: "Answer",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "BlogComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "BlogComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
