using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class FixManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPrivileges");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RolePrivileges");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserPrivileges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RolePrivileges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("de0b1da2-34af-4844-8e3b-e03f99e172ab"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("8436c0ac-fab5-41fe-a914-720622f80ca4"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("aa196dfb-e122-4e83-9fd7-d6786bade7cc"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("2a8a21fd-5cbb-4eb8-b738-f57f0807eccf"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("a9b10dcf-3cce-4814-810c-c2f6c0de1270"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("e695b354-009f-4b01-a759-297ec22c417a"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("6540c67e-7949-4751-adbc-bef4ce1d4286"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("959491d7-de56-4884-89d4-a6a165e1702b"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("0e5ee4f5-0b78-4652-a309-3bf4552f4517"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") },
                column: "Id",
                value: new Guid("4529fea9-e740-4d71-8d45-68700f64bb62"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("50b869d9-70e1-4fb1-890f-a934c3c3e446"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("d28912c3-077d-4d4f-9a34-5490a6dfceff"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("5043a598-7354-4659-8e05-8149824d1ccf"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("7e368856-b2e8-4924-9798-c12f709d579d"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("217bd2b3-ac7c-4bd7-b1db-b5d2a08bcc2c"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("fc42ef26-9ef0-435a-9cd8-191ec033986c"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("87ebc07f-6e0d-4622-b32f-2a430cb8612f"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") },
                column: "Id",
                value: new Guid("3f742155-c308-41fe-82e1-1d435d598f5b"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("16e0452c-953b-4090-89c5-1f5eb6a82637"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("dcf1134d-a616-4bb9-8c70-ce9c0e7799a0"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("6ff89af9-fc23-4a3e-b5af-47b24b72df33"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("b3a9b08e-b3f3-4e68-af0f-8bf6f5ee6745"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") },
                column: "Id",
                value: new Guid("78dde744-3ae6-494d-a69b-35c4835ef5e5"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("30f2d5a9-31ca-44d9-a195-e43b7e2ad229"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("0f15ebcb-9045-4adb-bdcd-d43040d7d335"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("9cd3b4eb-e728-479b-9969-6ea18399b28f"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("ceb7aee5-01ed-4b6d-8dcd-1207b8809433"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("a19318be-5b65-41a8-bc69-82d710e88121"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("76d53216-a09b-4121-9b52-53e0fd893032"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("2df791c0-468c-46d3-b987-51c2c85ff1fc"));

            migrationBuilder.UpdateData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") },
                column: "Id",
                value: new Guid("d03d7948-1538-442a-bde1-d03d251067bb"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("0a77139b-14ea-4ec9-bd40-eafc16beef85"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("4551aef9-fa14-453d-82ea-483c25f8e859"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("b58ccdec-23ed-43c7-814b-a1910d10dc2b"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("baf75ba0-60fe-41bf-8add-1b1e4f4302dd"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("fdf3b651-daed-4858-8ef1-87232b3cfdd1"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("9267ce41-b3fe-4698-9b55-353e198174ce"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("304ec4d6-4935-4a84-8d65-5401c802154c"));

            migrationBuilder.UpdateData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") },
                column: "Id",
                value: new Guid("b32f469e-a4ea-46c8-a486-bca9168720ab"));
        }
    }
}
