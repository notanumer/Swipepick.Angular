using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStudentsToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "QuestionStudent",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionStudent", x => new { x.QuestionsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_QuestionStudent_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionStudent_StudentsId",
                table: "QuestionStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionStudent");

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
    }
}
