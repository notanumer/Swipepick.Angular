using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdiotsChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "StudentAnswerVariant",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerVariant_QuestionId",
                table: "StudentAnswerVariant",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswerVariant_Questions_QuestionId",
                table: "StudentAnswerVariant",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswerVariant_Questions_QuestionId",
                table: "StudentAnswerVariant");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswerVariant_QuestionId",
                table: "StudentAnswerVariant");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "StudentAnswerVariant");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Questions_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
