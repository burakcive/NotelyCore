using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotelyCore.Persistence.Migrations
{
    public partial class LinkTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LevelOfImportance = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject", "UserId" },
                values: new object[] { 1, "Body 1", new DateTime(2019, 7, 25, 18, 46, 50, 746, DateTimeKind.Local).AddTicks(2608), null, 2, "Note 1", null });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject", "UserId" },
                values: new object[] { 2, "Body 2", new DateTime(2019, 7, 25, 18, 46, 50, 747, DateTimeKind.Local).AddTicks(4261), null, 1, "Note 2", null });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Body", "CreatedOn", "ModifiedOn", "Priority", "Subject", "UserId" },
                values: new object[] { 3, "Body 3", new DateTime(2019, 7, 25, 18, 46, 50, 747, DateTimeKind.Local).AddTicks(4272), null, 0, "Note 3", null });
        }
    }
}
