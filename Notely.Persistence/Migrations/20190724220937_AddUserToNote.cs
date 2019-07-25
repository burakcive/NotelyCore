using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class AddUserToNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 1, 9, 36, 344, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 1, 9, 36, 349, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 1, 9, 36, 349, DateTimeKind.Local).AddTicks(4886));

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 24, 21, 33, 28, 399, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 24, 21, 33, 28, 403, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 24, 21, 33, 28, 403, DateTimeKind.Local).AddTicks(7227));
        }
    }
}
