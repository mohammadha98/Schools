using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class migaddForenKeyBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogGroups_BlogGroupGroupId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeTypeId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogGroupGroupId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogTypeTypeId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogGroupGroupId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogTypeTypeId",
                table: "Blogs");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_GroupId",
                table: "Blogs",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TypeId",
                table: "Blogs",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogGroups_GroupId",
                table: "Blogs",
                column: "GroupId",
                principalTable: "BlogGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogTypes_TypeId",
                table: "Blogs",
                column: "TypeId",
                principalTable: "BlogTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogGroups_GroupId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogTypes_TypeId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_GroupId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TypeId",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogGroupGroupId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogTypeTypeId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogGroupGroupId",
                table: "Blogs",
                column: "BlogGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogTypeTypeId",
                table: "Blogs",
                column: "BlogTypeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogGroups_BlogGroupGroupId",
                table: "Blogs",
                column: "BlogGroupGroupId",
                principalTable: "BlogGroups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogTypes_BlogTypeTypeId",
                table: "Blogs",
                column: "BlogTypeTypeId",
                principalTable: "BlogTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
