using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class fix_School_Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "SchoolComments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "SchoolComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
