using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudentAnswersToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                unique: true);
        }
    }
}
