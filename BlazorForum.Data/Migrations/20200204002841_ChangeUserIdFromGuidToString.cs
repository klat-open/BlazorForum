using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorForum.Data.Migrations
{
    public partial class ChangeUserIdFromGuidToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ForumTopics",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "EditedBy",
                table: "ForumTopics",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ForumPosts",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "EditedBy",
                table: "ForumPosts",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ForumTopics",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<Guid>(
                name: "EditedBy",
                table: "ForumTopics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ForumPosts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<Guid>(
                name: "EditedBy",
                table: "ForumPosts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);
        }
    }
}
