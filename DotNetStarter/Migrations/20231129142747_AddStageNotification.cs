using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddStageNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TwoFactorsBackup_Code",
                table: "TwoFactorsBackup");

            migrationBuilder.DropColumn(
                name: "IsNotificationEnabled",
                table: "Stages");

            migrationBuilder.CreateTable(
                name: "StageNotifications",
                columns: table => new
                {
                    StageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageNotifications", x => new { x.StageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StageNotifications_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StageNotifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorsBackup_Code",
                table: "TwoFactorsBackup",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_StageNotifications_UserId_StageId",
                table: "StageNotifications",
                columns: new[] { "UserId", "StageId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageNotifications");

            migrationBuilder.DropIndex(
                name: "IX_TwoFactorsBackup_Code",
                table: "TwoFactorsBackup");

            migrationBuilder.AddColumn<bool>(
                name: "IsNotificationEnabled",
                table: "Stages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TwoFactorsBackup_Code",
                table: "TwoFactorsBackup",
                column: "Code",
                unique: true);
        }
    }
}
