using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAnswersToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "StudentAnswers");
        }
    }
}
