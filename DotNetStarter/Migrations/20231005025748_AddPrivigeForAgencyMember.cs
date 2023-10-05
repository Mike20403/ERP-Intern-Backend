using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AddPrivigeForAgencyMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId" },
                values: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });
        }
    }
}
