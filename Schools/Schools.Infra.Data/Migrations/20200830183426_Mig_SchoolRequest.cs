using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Mig_SchoolRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SchoolTeachers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SchoolGalleries",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SchoolRequests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SchoolName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BuildDate = table.Column<string>(nullable: false),
                    ShireId = table.Column<string>(nullable: false),
                    CityId = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(nullable: false),
                    Fax = table.Column<string>(nullable: false),
                    CellPhone = table.Column<string>(nullable: false),
                    TelePhone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    TrainingTypes = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_SchoolRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestGalleries",
                columns: table => new
                {
                    GalleryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestGalleries", x => x.GalleryId);
                    table.ForeignKey(
                        name: "FK_RequestGalleries_SchoolRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "SchoolRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestGalleries_RequestId",
                table: "RequestGalleries",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRequests_UserId",
                table: "SchoolRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestGalleries");

            migrationBuilder.DropTable(
                name: "SchoolRequests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SchoolTeachers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SchoolGalleries");

           
        }
    }
}
