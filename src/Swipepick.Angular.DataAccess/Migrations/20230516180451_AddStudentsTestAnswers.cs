using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsTestAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstAnswer",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "FourhAnswer",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "SecondAnswer",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "ThirdAnswer",
                table: "StudentAnswers");

            migrationBuilder.CreateTable(
                name: "StudentAnswerVariant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentAnswerId = table.Column<int>(type: "integer", nullable: false),
                    Variant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswerVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswerVariant_StudentAnswers_StudentAnswerId",
                        column: x => x.StudentAnswerId,
                        principalTable: "StudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerVariant_StudentAnswerId",
                table: "StudentAnswerVariant",
                column: "StudentAnswerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAnswerVariant");

            migrationBuilder.AddColumn<string>(
                name: "FirstAnswer",
                table: "StudentAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FourhAnswer",
                table: "StudentAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondAnswer",
                table: "StudentAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdAnswer",
                table: "StudentAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
