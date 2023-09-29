using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class FixRolesAndPrivilegesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("19208f3f-0c95-416f-a095-99650fb94490"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("844ef058-9bf3-4989-8717-101bf1887f85"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"), "UPDATE_PAYMENTS" },
                    { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), "VIEW_PROJECTS" },
                    { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), "DELETE_TALENTS" },
                    { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), "UPDATE_PROJECTS" },
                    { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), "CREATE_TASKS" },
                    { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), "CREATE_TALENTS" },
                    { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), "DELETE_AGENCY_MEMBERS" },
                    { new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"), "ACCEPT_PAYMENTS" },
                    { new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"), "CREATE_PAYMENTS" },
                    { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), "INVITE_TALENTS" },
                    { new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"), "CREATE_PROJECTS" },
                    { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), "REMOVE_TALENTS_FROM_PROJECT" },
                    { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), "UPDATE_TASKS" },
                    { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), "DELETE_TASKS" },
                    { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), "CREATE_AGENCY_MEMBERS" },
                    { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), "VIEW_AGENCY_MEMBERS" },
                    { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), "UPDATE_TALENTS" },
                    { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), "VIEW_TASKS" },
                    { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), "UPDATE_AGENCY_MEMBERS" },
                    { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), "VIEW_TALENTS" },
                    { new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"), "DELETE_PROJECTS" },
                    { new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"), "FINALIZE_PAYMENTS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), "AGENCY_MEMBER" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                column: "Gender",
                value: 1);

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("de0b1da2-34af-4844-8e3b-e03f99e172ab") },
                    { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("8436c0ac-fab5-41fe-a914-720622f80ca4") },
                    { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("aa196dfb-e122-4e83-9fd7-d6786bade7cc") },
                    { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("2a8a21fd-5cbb-4eb8-b738-f57f0807eccf") },
                    { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("a9b10dcf-3cce-4814-810c-c2f6c0de1270") },
                    { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("e695b354-009f-4b01-a759-297ec22c417a") },
                    { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("6540c67e-7949-4751-adbc-bef4ce1d4286") },
                    { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("959491d7-de56-4884-89d4-a6a165e1702b") },
                    { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("0e5ee4f5-0b78-4652-a309-3bf4552f4517") },
                    { new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("4529fea9-e740-4d71-8d45-68700f64bb62") },
                    { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("50b869d9-70e1-4fb1-890f-a934c3c3e446") },
                    { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("d28912c3-077d-4d4f-9a34-5490a6dfceff") },
                    { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("5043a598-7354-4659-8e05-8149824d1ccf") },
                    { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("7e368856-b2e8-4924-9798-c12f709d579d") },
                    { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("217bd2b3-ac7c-4bd7-b1db-b5d2a08bcc2c") },
                    { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("fc42ef26-9ef0-435a-9cd8-191ec033986c") },
                    { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("87ebc07f-6e0d-4622-b32f-2a430cb8612f") },
                    { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("3f742155-c308-41fe-82e1-1d435d598f5b") },
                    { new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("16e0452c-953b-4090-89c5-1f5eb6a82637") },
                    { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("dcf1134d-a616-4bb9-8c70-ce9c0e7799a0") },
                    { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("6ff89af9-fc23-4a3e-b5af-47b24b72df33") },
                    { new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("b3a9b08e-b3f3-4e68-af0f-8bf6f5ee6745") },
                    { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f") },
                    { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f") },
                    { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), new Guid("78dde744-3ae6-494d-a69b-35c4835ef5e5") },
                    { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("30f2d5a9-31ca-44d9-a195-e43b7e2ad229") },
                    { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("0f15ebcb-9045-4adb-bdcd-d43040d7d335") },
                    { new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("9cd3b4eb-e728-479b-9969-6ea18399b28f") },
                    { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("ceb7aee5-01ed-4b6d-8dcd-1207b8809433") },
                    { new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("a19318be-5b65-41a8-bc69-82d710e88121") },
                    { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("76d53216-a09b-4121-9b52-53e0fd893032") },
                    { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("2df791c0-468c-46d3-b987-51c2c85ff1fc") },
                    { new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"), new Guid("d03d7948-1538-442a-bde1-d03d251067bb") }
                });

            migrationBuilder.InsertData(
                table: "UserPrivileges",
                columns: new[] { "PrivilegeId", "UserId", "Id" },
                values: new object[,]
                {
                    { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("0a77139b-14ea-4ec9-bd40-eafc16beef85") },
                    { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("4551aef9-fa14-453d-82ea-483c25f8e859") },
                    { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("b58ccdec-23ed-43c7-814b-a1910d10dc2b") },
                    { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("baf75ba0-60fe-41bf-8add-1b1e4f4302dd") },
                    { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("fdf3b651-daed-4858-8ef1-87232b3cfdd1") },
                    { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("9267ce41-b3fe-4698-9b55-353e198174ce") },
                    { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("304ec4d6-4935-4a84-8d65-5401c802154c") },
                    { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("b32f469e-a4ea-46c8-a486-bca9168720ab") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9a1edd05-bd24-462e-9754-534ec573745f"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"), new Guid("36a36642-44db-4e8d-8cc8-adc387d73150") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"), new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("183bc93e-89f7-41b0-9948-724194af2302"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("50817957-ef43-4393-b1a4-d557dc936daa"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7") });

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("183bc93e-89f7-41b0-9948-724194af2302"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("50817957-ef43-4393-b1a4-d557dc936daa"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9a1edd05-bd24-462e-9754-534ec573745f"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), "SUGGEST_TERMS_WITHOUT_SPECIFYING_A_GLOSSARY" },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), "MANAGE_ALL_TMS" },
                    { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), "MANAGE_ORDERS" },
                    { new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"), "MANAGE_USERS" },
                    { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), "VIEW_ALL_PROJECTS" },
                    { new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"), "MANAGE_SERVICE_TEMPLATES" },
                    { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), "MANAGE_PROJECT_TEMPLATES" },
                    { new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"), "MANAGE_PAID_LINGUISTIC_ASSETS" },
                    { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), "MANAGE_LINGUISTIC_ASSETS_IN_ALL_PROJECTS" },
                    { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), "CREATE_ANY_PROJECTS" },
                    { new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"), "MANAGE_VENDORS" },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), "MANAGE_ALL_GLOSSARIES" },
                    { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), "MANAGE_CLIENTS_AND_PROJECT_TAGS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"), "RESOURCE_MANAGER" },
                    { new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), "LOCALIZATION_TEAM" }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("1f0e1d76-2f51-40f3-9571-92bd0ba288b9") },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f") },
                    { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("8bfee646-f1eb-41d5-a045-8fb7773d09a9") },
                    { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("3a9f0b14-19df-4e2a-b522-c63e813510a9") },
                    { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("391b873b-247f-4e41-8fc7-8d8697e5240c") },
                    { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("e3ad16fb-0983-4b76-b900-e1512a1de3f9") },
                    { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("87491c80-15df-482c-87a2-e4770a7c1e5a") },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("15306c3c-4888-4fef-b12c-8e307929cd1f") },
                    { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), new Guid("75041757-4085-42ce-8800-10610b1f6091") },
                    { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("9de33dad-f693-4be9-9e0d-69b687c6b682") },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("dd11ec0b-3c25-44a7-bda0-c281e75683a6") },
                    { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("b240f7dd-75dc-4595-a491-144cb1678406") },
                    { new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("9dbbfae8-7017-4a95-923d-c439b08d7110") },
                    { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("b5855e40-ece8-4cb4-9acc-c87fa39c7543") },
                    { new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("9543579e-5ef5-472b-acc2-de08a867c38c") },
                    { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("d0b42a06-af2f-4348-b299-fcfddc72a142") },
                    { new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("8d378b56-9c39-4c7e-8620-38c314821fef") },
                    { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("d7a9c6f5-c519-4235-97f7-941c826f97d5") },
                    { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("b8af3f12-42b5-4464-85bc-07d2315a61e1") },
                    { new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("849c8950-e066-4543-9ed8-410a26916c0a") },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("0f467342-1e68-4cf5-85f3-46fce0948dad") },
                    { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), new Guid("44c3bfa4-0843-4c98-8c73-4106e452f305") },
                    { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"), new Guid("d843a16e-59b8-4fe3-b860-9a6200f68a4b") },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"), new Guid("92e615d3-2fe3-4a34-94dd-88d1f17792de") },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"), new Guid("526e8242-f5a4-481d-8c16-5a8d953cd713") },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), new Guid("1f96dc48-84f7-4dfd-a45e-e5c17a6f45a6") },
                    { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), new Guid("c4426758-be79-4e70-a980-2f555103fb98") },
                    { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), new Guid("14d9869e-7283-4a86-afbf-b93a1cbcbbcb") },
                    { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), new Guid("5b789d79-3444-4437-8d33-270f5024c57a") },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"), new Guid("63fb0ea1-c5a2-44b4-85ae-e9ba1a0d2c93") }
                });

            migrationBuilder.InsertData(
                table: "UserPrivileges",
                columns: new[] { "PrivilegeId", "UserId", "Id" },
                values: new object[,]
                {
                    { new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("06346a5f-2681-4177-8ed1-5fc487007911") },
                    { new Guid("19208f3f-0c95-416f-a095-99650fb94490"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("bfd1ddc4-d92e-40d5-be7c-52863a4529d1") },
                    { new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("72af926f-b0a5-421b-85ff-293fdca1cc4e") },
                    { new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("aa58599d-743d-4f39-b3c1-9f4f0f561d5e") },
                    { new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("1beafe73-0317-44d1-b8c0-12e2e7a85236") },
                    { new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("e23e2a09-31be-4516-b570-c0e17290ace4") },
                    { new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("810fd972-1080-4943-9383-60f0961fea4c") },
                    { new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("8c620425-8f7d-43e5-82fa-17794c22a208") },
                    { new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("c65a5602-5d5e-4ae7-947a-1372a5b27dd2") },
                    { new Guid("844ef058-9bf3-4989-8717-101bf1887f85"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("81cba8a1-9a35-456e-971e-5cfa7030c7a4") },
                    { new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("999c7d5e-f5f1-48dc-90bc-32bcc524e463") },
                    { new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("b5ba8a36-6c3c-4ee2-bb4d-a938dd546395") },
                    { new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"), new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), new Guid("438dff74-2a59-43a8-a5fc-c63000fafa6d") }
                });
        }
    }
}
