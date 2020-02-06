using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorForum.Data.Migrations
{
    public partial class AddRemainingAssociatedTableIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumTopics_ForumCategories_ForumCategoryId",
                table: "ForumTopics");

            migrationBuilder.AlterColumn<int>(
                name: "ForumCategoryId",
                table: "ForumTopics",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ForumTopicId",
                table: "ForumPosts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId",
                principalTable: "ForumTopics",
                principalColumn: "ForumTopicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumTopics_ForumCategories_ForumCategoryId",
                table: "ForumTopics",
                column: "ForumCategoryId",
                principalTable: "ForumCategories",
                principalColumn: "ForumCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumTopics_ForumCategories_ForumCategoryId",
                table: "ForumTopics");

            migrationBuilder.AlterColumn<int>(
                name: "ForumCategoryId",
                table: "ForumTopics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ForumTopicId",
                table: "ForumPosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId",
                principalTable: "ForumTopics",
                principalColumn: "ForumTopicId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumTopics_ForumCategories_ForumCategoryId",
                table: "ForumTopics",
                column: "ForumCategoryId",
                principalTable: "ForumCategories",
                principalColumn: "ForumCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
