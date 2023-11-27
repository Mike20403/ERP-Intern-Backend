using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddBackUpCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwoFactorsBackup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoFactorsBackup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TwoFactorsBackup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorsBackup_Code",
                table: "TwoFactorsBackup",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorsBackup_UserId",
                table: "TwoFactorsBackup",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwoFactorsBackup");
        }
    }
}
