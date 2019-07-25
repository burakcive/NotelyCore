using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class EnumIntConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(1431), 2 });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(9619), 1 });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(9629), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 1, 9, 36, 344, DateTimeKind.Local).AddTicks(4883), "Critical" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 1, 9, 36, 349, DateTimeKind.Local).AddTicks(4886), "Neutral" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 25, 1, 9, 36, 349, DateTimeKind.Local).AddTicks(4886), "Low" });
        }
    }
}
