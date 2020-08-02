using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularBlog.Infrastructure.Data.Migrations.Oracle
{
    public partial class PostAuthorRelations_Oracle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Posts",
                type: "NVARCHAR2(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
