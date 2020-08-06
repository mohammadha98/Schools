using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schools.Infra.Data.Migrations
{
    public partial class Build_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.CreateTable(
                name: "BlogGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogGroups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "BlogTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_SchoolGroups_SchoolGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SchoolGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shires",
                columns: table => new
                {
                    ShireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShireTitle = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shires", x => x.ShireId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    ActiveCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UserAvatar = table.Column<string>(maxLength: 200, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 400, nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    BlogText = table.Column<string>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    BlogVisit = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    BlogGroupGroupId = table.Column<int>(nullable: true),
                    BlogTypeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogGroups_BlogGroupGroupId",
                        column: x => x.BlogGroupGroupId,
                        principalTable: "BlogGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogTypes_BlogTypeTypeId",
                        column: x => x.BlogTypeTypeId,
                        principalTable: "BlogTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShireId = table.Column<int>(nullable: false),
                    CityTitle = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Shires_ShireId",
                        column: x => x.ShireId,
                        principalTable: "Shires",
                        principalColumn: "ShireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Answer = table.Column<int>(nullable: true),
                    SecurityCode = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(nullable: false),
                    AreaTitle = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolManager = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    SubGroupId = table.Column<int>(nullable: true),
                    ShireId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: true),
                    SchoolTitle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SchoolPhone = table.Column<string>(nullable: false),
                    SchoolEmail = table.Column<string>(nullable: false),
                    SchoolFax = table.Column<string>(nullable: false),
                    SchoolAddress = table.Column<string>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    BuildDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_Schools_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SchoolGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_Users_SchoolManager",
                        column: x => x.SchoolManager,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_Shires_ShireId",
                        column: x => x.ShireId,
                        principalTable: "Shires",
                        principalColumn: "ShireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_SchoolGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "SchoolGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Answer = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    SchoolCommentCommentId = table.Column<int>(nullable: true),
                    SchoolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_SchoolComments_SchoolComments_SchoolCommentCommentId",
                        column: x => x.SchoolCommentCommentId,
                        principalTable: "SchoolComments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolComments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolCourses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_SchoolCourses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolGalleries",
                columns: table => new
                {
                    GalleryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolGalleries", x => x.GalleryId);
                    table.ForeignKey(
                        name: "FK_SchoolGalleries_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolLikes",
                columns: table => new
                {
                    SchoolLikeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    isLiked = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolLikes", x => x.SchoolLikeId);
                    table.ForeignKey(
                        name: "FK_SchoolLikes_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolRates",
                columns: table => new
                {
                    RateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolRates", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_SchoolRates_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTeachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SchoolId = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTeachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_SchoolTeachers_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolTeachers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTrainingTypes",
                columns: table => new
                {
                    STT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTrainingTypes", x => x.STT_ID);
                    table.ForeignKey(
                        name: "FK_SchoolTrainingTypes_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolTrainingTypes_TrainingTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TrainingTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchoolVisits",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    UserIp = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolVisits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_SchoolVisits_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolVisits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherRates",
                columns: table => new
                {
                    RateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherRates", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_TeacherRates_SchoolTeachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "SchoolTeachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_BlogId",
                table: "BlogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogGroupGroupId",
                table: "Blogs",
                column: "BlogGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogTypeTypeId",
                table: "Blogs",
                column: "BlogTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ShireId",
                table: "Cities",
                column: "ShireId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_SchoolCommentCommentId",
                table: "SchoolComments",
                column: "SchoolCommentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_SchoolId",
                table: "SchoolComments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_UserId",
                table: "SchoolComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourses_SchoolId",
                table: "SchoolCourses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGalleries_SchoolId",
                table: "SchoolGalleries",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolGroups_ParentId",
                table: "SchoolGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLikes_SchoolId",
                table: "SchoolLikes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolLikes_UserId",
                table: "SchoolLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRates_SchoolId",
                table: "SchoolRates",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRates_UserId",
                table: "SchoolRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_AreaId",
                table: "Schools",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CityId",
                table: "Schools",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_GroupId",
                table: "Schools",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SchoolManager",
                table: "Schools",
                column: "SchoolManager");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_ShireId",
                table: "Schools",
                column: "ShireId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_SubGroupId",
                table: "Schools",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeachers_SchoolId",
                table: "SchoolTeachers",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTeachers_UserId",
                table: "SchoolTeachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTrainingTypes_SchoolId",
                table: "SchoolTrainingTypes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolTrainingTypes_TypeId",
                table: "SchoolTrainingTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolVisits_SchoolId",
                table: "SchoolVisits",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolVisits_UserId",
                table: "SchoolVisits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherRates_TeacherId",
                table: "TeacherRates",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherRates_UserId",
                table: "TeacherRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "SchoolComments");

            migrationBuilder.DropTable(
                name: "SchoolCourses");

            migrationBuilder.DropTable(
                name: "SchoolGalleries");

            migrationBuilder.DropTable(
                name: "SchoolLikes");

            migrationBuilder.DropTable(
                name: "SchoolRates");

            migrationBuilder.DropTable(
                name: "SchoolTrainingTypes");

            migrationBuilder.DropTable(
                name: "SchoolVisits");

            migrationBuilder.DropTable(
                name: "TeacherRates");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "TrainingTypes");

            migrationBuilder.DropTable(
                name: "SchoolTeachers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BlogGroups");

            migrationBuilder.DropTable(
                name: "BlogTypes");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "SchoolGroups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Shires");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sample = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }
    }
}
