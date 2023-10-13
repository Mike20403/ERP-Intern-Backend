using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NextCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.CheckConstraint("CK_Prev_Next_Not_Equal", "[PrevCardId] <> [NextCardId]");
                    table.ForeignKey(
                        name: "FK_Cards_Cards_NextCardId",
                        column: x => x.NextCardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Cards_PrevCardId",
                        column: x => x.PrevCardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"),
                column: "Name",
                value: "CREATE_CARDS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9a1edd05-bd24-462e-9754-534ec573745f"),
                column: "Name",
                value: "UPDATE_CARDS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"),
                column: "Name",
                value: "DELETE_CARDS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"),
                column: "Name",
                value: "VIEW_CARDS");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_NextCardId",
                table: "Cards",
                column: "NextCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PrevCardId_NextCardId",
                table: "Cards",
                columns: new[] { "PrevCardId", "NextCardId" },
                unique: true,
                filter: "[PrevCardId] IS NOT NULL AND [NextCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_StageId",
                table: "Cards",
                column: "StageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"),
                column: "Name",
                value: "CREATE_TASKS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9a1edd05-bd24-462e-9754-534ec573745f"),
                column: "Name",
                value: "UPDATE_TASKS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"),
                column: "Name",
                value: "DELETE_TASKS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"),
                column: "Name",
                value: "VIEW_TASKS");
        }
    }
}
