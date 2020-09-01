using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Fix_Request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShireId",
                table: "SchoolRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "SchoolRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuildDate",
                table: "SchoolRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShireId",
                table: "SchoolRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "SchoolRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "BuildDate",
                table: "SchoolRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
