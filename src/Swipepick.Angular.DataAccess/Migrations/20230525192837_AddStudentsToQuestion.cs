using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_QuestionId",
                table: "Students",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Questions_QuestionId",
                table: "Students",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Questions_QuestionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_QuestionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
