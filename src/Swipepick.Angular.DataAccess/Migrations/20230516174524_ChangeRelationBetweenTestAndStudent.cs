using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationBetweenTestAndStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTest");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TestId",
                table: "Students",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tests_TestId",
                table: "Students",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tests_TestId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TestId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "StudentTest",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "integer", nullable: false),
                    TestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest", x => new { x.StudentsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_StudentTest_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_TestsId",
                table: "StudentTest",
                column: "TestsId");
        }
    }
}
