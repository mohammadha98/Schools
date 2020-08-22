using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class migUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatinalCode",
                table: "Users",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelNumber",
                table: "Users",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NatinalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TelNumber",
                table: "Users");
        }
    }
}
