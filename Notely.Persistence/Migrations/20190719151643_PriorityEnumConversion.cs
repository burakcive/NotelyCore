using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class PriorityEnumConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2019, 7, 19, 18, 16, 43, 627, DateTimeKind.Local).AddTicks(3790), "Critical" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 19, 18, 16, 43, 628, DateTimeKind.Local).AddTicks(3117), "Neutral" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 19, 18, 16, 43, 628, DateTimeKind.Local).AddTicks(3128), "Low" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2019, 7, 19, 17, 51, 40, 66, DateTimeKind.Local).AddTicks(1580), 2 });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 19, 17, 51, 40, 67, DateTimeKind.Local).AddTicks(2524), 1 });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Priority" },
                values: new object[] { new DateTime(2019, 7, 19, 17, 51, 40, 67, DateTimeKind.Local).AddTicks(2537), 0 });
        }
    }
}
