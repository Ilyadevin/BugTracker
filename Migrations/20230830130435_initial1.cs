using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugTracker.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BugPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BugClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugPriority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastInteraction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScreenShot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    PriorityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bugs_BugPriority_PriorityID",
                        column: x => x.PriorityID,
                        principalTable: "BugPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BugPriority",
                columns: new[] { "Id", "BugClassName", "Description" },
                values: new object[,]
                {
                    { 1, "Low", "Description" },
                    { 2, "Medium", "Description" },
                    { 3, "High", "Description" }
                });

            migrationBuilder.InsertData(
                table: "Bugs",
                columns: new[] { "Id", "CreationDate", "DateOfLastInteraction", "IsSolved", "LongDescription", "Name", "PriorityID", "ScreenShot", "ShortDescription" },
                values: new object[,]
                {
                    { new Guid("4302e22f-7871-45fc-a920-0d8fab157a9f"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), false, "Long descr", "error in smth, middle priority", 2, "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png", "shortdescr" },
                    { new Guid("951e0073-b171-4cf7-a217-08f9fe128b7e"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), null, false, "Long descr", "error in smth, low proirity", 1, "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png", "shortdescr" },
                    { new Guid("b759ed5c-24e3-42fe-b2be-1ffc48b2d50d"), new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), false, "Long descr", "error in smth, high priority", 3, "/img/34a012f9-68cf-4e21-81b2-2023d75c4f96.png", "shortdescr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_PriorityID",
                table: "Bugs",
                column: "PriorityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "BugPriority");
        }
    }
}
