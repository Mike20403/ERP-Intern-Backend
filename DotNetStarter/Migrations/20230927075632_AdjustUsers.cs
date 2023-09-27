using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                column: "Gender",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");
        }
    }
}
