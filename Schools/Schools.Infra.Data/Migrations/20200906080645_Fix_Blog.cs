using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Fix_Blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswersComments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "IsAdminRead",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "ShortLink",
                table: "Blogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Answer",
                table: "BlogComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortLink",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "BlogComments");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BlogComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminRead",
                table: "BlogComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BlogComments",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BlogComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SecurityCode",
                table: "BlogComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnswersComments",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersComments", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_AnswersComments_BlogComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "BlogComments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswersComments_Users_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswersComments_CommentId",
                table: "AnswersComments",
                column: "CommentId");
        }
    }
}
