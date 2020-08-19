using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class SchoolComments_Answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolComments_SchoolComments_SchoolCommentCommentId",
                table: "SchoolComments");

            migrationBuilder.DropIndex(
                name: "IX_SchoolComments_SchoolCommentCommentId",
                table: "SchoolComments");

            migrationBuilder.DropColumn(
                name: "SchoolCommentCommentId",
                table: "SchoolComments");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_Answer",
                table: "SchoolComments",
                column: "Answer");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolComments_SchoolComments_Answer",
                table: "SchoolComments",
                column: "Answer",
                principalTable: "SchoolComments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolComments_SchoolComments_Answer",
                table: "SchoolComments");

            migrationBuilder.DropIndex(
                name: "IX_SchoolComments_Answer",
                table: "SchoolComments");

            migrationBuilder.AddColumn<int>(
                name: "SchoolCommentCommentId",
                table: "SchoolComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_SchoolCommentCommentId",
                table: "SchoolComments",
                column: "SchoolCommentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolComments_SchoolComments_SchoolCommentCommentId",
                table: "SchoolComments",
                column: "SchoolCommentCommentId",
                principalTable: "SchoolComments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
