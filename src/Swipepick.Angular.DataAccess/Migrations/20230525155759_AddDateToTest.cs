using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swipepick.Angular.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedAt",
                table: "Tests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "RemovedAt",
                table: "Tests",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UpdatedAt",
                table: "Tests",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "AnswerVariant",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Tests");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "AnswerVariant",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerVariant_Answers_AnswerId",
                table: "AnswerVariant",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
