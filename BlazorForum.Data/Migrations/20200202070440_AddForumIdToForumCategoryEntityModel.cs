using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorForum.Data.Migrations
{
    public partial class AddForumIdToForumCategoryEntityModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumCategories_Forums_ForumId",
                table: "ForumCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumCategories_Forums_ForumId",
                table: "ForumCategories",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "ForumId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumCategories_Forums_ForumId",
                table: "ForumCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "ForumCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ForumCategories_Forums_ForumId",
                table: "ForumCategories",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "ForumId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
