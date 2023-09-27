using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivileges", x => new { x.RoleId, x.PrivilegeId });
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Otps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Otps_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivileges",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivilegeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivileges", x => new { x.UserId, x.PrivilegeId });
                    table.ForeignKey(
                        name: "FK_UserPrivileges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivileges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"), "PROJECT_MANAGER" },
                    { new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), "ADMINISTRATOR" },
                    { new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"), "TALENT" },
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
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Firstname", "Lastname", "Password", "PhoneNumber", "RoleId", "Status", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { new Guid("a3edc636-8153-42af-85a1-65dac56cded7"), "System", new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Yopmail", "$2a$11$61sJj9Y7idWPUoWTysZ81u7B0veE3dPhfdPGIJbi.TB0r/NtgR0k2", "0333333333", new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"), 1, "System", new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin.dotnetstarter@yopmail.com" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Otps_UserId",
                table: "Otps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_Name",
                table: "Privileges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_PrivilegeId",
                table: "RolePrivileges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivileges_PrivilegeId",
                table: "UserPrivileges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otps");

            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropTable(
                name: "UserPrivileges");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
