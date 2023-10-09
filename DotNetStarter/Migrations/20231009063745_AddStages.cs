using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddStages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"), "VIEW_STAGES" },
                    { new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e"), "UPDATE_STAGES" }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                    { new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                    { new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ProjectId_Name",
                table: "Stages",
                columns: new[] { "ProjectId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ProjectId_Order",
                table: "Stages",
                columns: new[] { "ProjectId", "Order" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e"));
        }
    }
}
