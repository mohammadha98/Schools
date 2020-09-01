using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class mig_add_Isaccept_SchoolRequst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "SchoolRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "SchoolRequests");
        }
    }
}
