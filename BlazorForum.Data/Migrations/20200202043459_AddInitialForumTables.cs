using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorForum.Data.Migrations
{
    public partial class AddInitialForumTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    ForumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.ForumId);
                });

            migrationBuilder.CreateTable(
                name: "ForumCategories",
                columns: table => new
                {
                    ForumCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    ForumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategories", x => x.ForumCategoryId);
                    table.ForeignKey(
                        name: "FK_ForumCategories_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "ForumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumTopics",
                columns: table => new
                {
                    ForumTopicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    TopicText = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserIP = table.Column<string>(maxLength: 50, nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: true),
                    Flags = table.Column<int>(nullable: false),
                    EditReason = table.Column<string>(maxLength: 100, nullable: true),
                    EditedBy = table.Column<Guid>(nullable: true),
                    IsModeratorChanged = table.Column<bool>(nullable: false),
                    DeleteReason = table.Column<string>(maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ForumCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopics", x => x.ForumTopicId);
                    table.ForeignKey(
                        name: "FK_ForumTopics_ForumCategories_ForumCategoryId",
                        column: x => x.ForumCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "ForumCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumPosts",
                columns: table => new
                {
                    ForumPostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    PostText = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UserIP = table.Column<string>(maxLength: 50, nullable: true),
                    Flags = table.Column<int>(nullable: false),
                    EditedDate = table.Column<DateTime>(nullable: true),
                    EditReason = table.Column<string>(maxLength: 100, nullable: true),
                    EditedBy = table.Column<Guid>(nullable: true),
                    IsModeratorChanged = table.Column<bool>(nullable: false),
                    DeleteReason = table.Column<string>(maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ForumTopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPosts", x => x.ForumPostId);
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                        column: x => x.ForumTopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "ForumTopicId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumCategories_ForumId",
                table: "ForumCategories",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumTopics_ForumCategoryId",
                table: "ForumTopics",
                column: "ForumCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumTopics");

            migrationBuilder.DropTable(
                name: "ForumCategories");

            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
