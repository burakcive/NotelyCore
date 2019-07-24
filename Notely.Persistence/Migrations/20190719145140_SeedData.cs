using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject" },
                values: new object[] { 1, "Body 1", new DateTime(2019, 7, 19, 17, 51, 40, 66, DateTimeKind.Local).AddTicks(1580), null, 2, "Note 1" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject" },
                values: new object[] { 2, "Body 2", new DateTime(2019, 7, 19, 17, 51, 40, 67, DateTimeKind.Local).AddTicks(2524), null, 1, "Note 2" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject" },
                values: new object[] { 3, "Body 3", new DateTime(2019, 7, 19, 17, 51, 40, 67, DateTimeKind.Local).AddTicks(2537), null, 0, "Note 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3);
        }
    }
}
