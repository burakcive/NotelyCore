using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class AddUserForNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 18, 46, 50, 746, DateTimeKind.Local).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 18, 46, 50, 747, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 18, 46, 50, 747, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UserId",
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
                value: new DateTime(2019, 7, 25, 18, 44, 28, 614, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 18, 44, 28, 615, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 7, 25, 18, 44, 28, 615, DateTimeKind.Local).AddTicks(7829));
        }
    }
}
