using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Social_Networks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "SchoolRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    SW_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkName = table.Column<string>(nullable: true),
                    NetWorkLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SW_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "SchoolRequests");
        }
    }
}
