using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class RenameToStaffMemberPrivileges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"),
                column: "Name",
                value: "DELETE_STAFF_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"),
                column: "Name",
                value: "CREATE_STAFF_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"),
                column: "Name",
                value: "VIEW_STAFF_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"),
                column: "Name",
                value: "UPDATE_STAFF_MEMBERS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"),
                column: "Name",
                value: "DELETE_AGENCY_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"),
                column: "Name",
                value: "CREATE_AGENCY_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"),
                column: "Name",
                value: "VIEW_AGENCY_MEMBERS");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"),
                column: "Name",
                value: "UPDATE_AGENCY_MEMBERS");
        }
    }
}
