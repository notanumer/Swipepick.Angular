using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTestDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }
    }
}
