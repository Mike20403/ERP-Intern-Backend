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
                    { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), "MANAGE_CLIENTS_AND_PROJECT_TAGS" },
                    { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), "MANAGE_ORDERS" },
                    { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), "MANAGE_LINGUISTIC_ASSETS_IN_ALL_PROJECTS" },
                    { new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"), "MANAGE_PAID_LINGUISTIC_ASSETS" },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), "MANAGE_ALL_TMS" },
                    { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), "VIEW_ALL_PROJECTS" },
                    { new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"), "MANAGE_USERS" },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), "MANAGE_ALL_GLOSSARIES" },
                    { new Guid("995663ff-ec71-4c87-999d-2a617af718a4"), "MANAGE_SERVICE_TEMPLATES" },
                    { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), "MANAGE_PROJECT_TEMPLATES" },
                    { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), "SUGGEST_TERMS_WITHOUT_SPECIFYING_A_GLOSSARY" },
                    { new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"), "MANAGE_VENDORS" },
                    { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), "CREATE_ANY_PROJECTS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), "ADMINISTRATOR" },
                    { new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), "PROJECT_MANAGER" },
                    { new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb"), "RESOURCE_MANAGER" },
                    { new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), "LOCALIZATION_TEAM" },
                    { new Guid("d306c1a7-7810-4363-8816-7459a1bb18d8"), "TALENT" }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("2b1d261f-6ecd-4d47-b156-97137b43dee7") },
                    { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("74be5836-2821-4865-b598-81f56c7b08a9") },
                    { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("6b0e2b66-b1b9-41aa-b487-ae4509df91ff") },
                    { new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("4a43b9d0-1ddf-4e2d-9353-40b75c78312f") },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("e4bc7792-d40b-4408-bce5-be15be8ee4b4") },
                    { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("99f1f7d3-4c0a-4b85-a888-9a95cca8ba84") },
                    { new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("ef1e03d7-1154-42f9-9a5b-d6c2d32c2373") },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("6848d5b3-6aca-41ad-bf21-398d23f1acfc") },
                    { new Guid("995663ff-ec71-4c87-999d-2a617af718a4"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("fc8aa44d-8df8-4522-8b7d-cc8256689bc1") },
                    { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("2bc6c19a-df12-448c-b3fa-a9f0a6d8ea1b") },
                    { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("dba1592d-1bb1-45d6-b5b3-53d667148aa2") },
                    { new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("5e185e09-f99f-4e58-9337-d9c3aa619969") },
                    { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), new Guid("b8ee6d37-e0f5-4b7c-8d71-299f2564b3e3") },
                    { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("ef477335-b946-4059-8ec5-8a5f87f9ed48") },
                    { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("baf3088d-78a1-4a8a-98e5-e643a2dd13bc") },
                    { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("002c4267-ccb1-4840-9e7b-8d6e92b0e52c") },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("ec12f797-d476-4cff-9bd6-6292cc9aaca1") },
                    { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("772b2f57-2492-45d8-b822-1521fd392c8d") },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("b00a2d25-f9aa-4aea-afa3-c74c2aa7bb0f") },
                    { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("c8c13c16-9fed-438d-b0b2-fe3d4ca206cb") },
                    { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("4c98e5ad-ec24-45fd-a070-0357dda2d277") },
                    { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"), new Guid("1c0a093c-005a-46d5-ab2e-4e0abd227d66") },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb"), new Guid("222e8cc1-48e0-4a1c-bdee-3820dcbe5db5") },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb"), new Guid("8f825e74-9694-41ac-a00b-3f183b7e65ce") },
                    { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb"), new Guid("10572898-1050-40ea-a56d-49a0a2447c96") },
                    { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), new Guid("05bc9cf0-f573-4997-92fa-d147df9cacbb") },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), new Guid("bfd8e8bb-0966-4337-9c5b-82b906ee6549") },
                    { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), new Guid("8e112381-54ce-4d40-a63b-7953211f5d8b") },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), new Guid("86415695-3c6c-4813-a702-cbadbf19fcca") },
                    { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"), new Guid("63ff295e-b36b-4fb8-a990-9fc42b604309") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Firstname", "Lastname", "Password", "PhoneNumber", "RoleId", "Status", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), "System", new DateTime(2023, 9, 5, 20, 20, 51, 227, DateTimeKind.Local).AddTicks(5607), "Admin", "Yopmail", "$2a$11$czrwjGpSHr/CRlcWWX4Pd.lv0.HOB4L1/C7fuPOwvYhxfpYZsCjG6", "0333333333", new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"), 1, "System", new DateTime(2023, 9, 5, 20, 20, 51, 227, DateTimeKind.Local).AddTicks(5607), "admin.dotnetstarter@yopmail.com" });

            migrationBuilder.InsertData(
                table: "UserPrivileges",
                columns: new[] { "PrivilegeId", "UserId", "Id" },
                values: new object[,]
                {
                    { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("b42f2859-a19c-49dd-98bb-01a96b74876c") },
                    { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("7f0e1a50-0fd3-4da8-bd1c-cfde7cfb7bc2") },
                    { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("a09dfbdd-1afd-4bec-b2bf-c7241b1826a8") },
                    { new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("05a6680c-757f-40dd-b033-60f8582bc28b") },
                    { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("1887c0e7-13fa-4a4f-b7e5-772754bc2008") },
                    { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("ebdb3b1f-e6c9-4687-9460-6593cf9afa71") },
                    { new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("f99ae8aa-51c0-4a35-9b3f-fd15002befd3") },
                    { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("d157a0ff-9e33-47fc-8868-b40c5425a00d") },
                    { new Guid("995663ff-ec71-4c87-999d-2a617af718a4"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("db328eef-da81-4be8-8e51-57e85e0b33ea") },
                    { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("f5b40ad7-0a50-4bd3-92be-2278dda51b54") },
                    { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("dde9988b-9066-4d0f-ae02-4593b6a96b3c") },
                    { new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("76e8db09-b267-4319-85ba-00c78e765f04") },
                    { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"), new Guid("11af8c9e-cfe4-4894-9dea-53538477812a") }
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
