using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetStarter.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("995663ff-ec71-4c87-999d-2a617af718a4"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("29aa2668-12d1-484b-b04b-93b5d380c114") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d306c1a7-7810-4363-8816-7459a1bb18d8"));

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("995663ff-ec71-4c87-999d-2a617af718a4"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("f90b00af-b217-4714-b638-adcb9248e885"), new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661") });

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("301940eb-2f5c-4d01-aa1a-01694da06a7c"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("471488cb-5306-46ed-883e-97fa1ec073b2"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("489bbacf-f6ac-4a80-bf33-a89473839c5d"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("51d3cc91-396d-4c1b-a400-3484dedaa21a"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("5917352e-896c-4b77-a074-cabb3d6cae1b"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("63b82dde-6c06-4b2d-aeeb-32f4fb93b7ff"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("76202262-ad72-41b1-9184-6c1934e0d85a"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("8e83760d-1a14-4d55-9fab-bd4ddc082894"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("995663ff-ec71-4c87-999d-2a617af718a4"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9c8533af-3487-4fad-9667-2d93f5cc9fda"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("a8dcdd64-261a-4408-ad1c-905d580ebb82"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("d50920b7-db8c-4300-9b10-c7f35febb5c7"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("f90b00af-b217-4714-b638-adcb9248e885"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("29aa2668-12d1-484b-b04b-93b5d380c114"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4bafb3e3-7675-462f-8b88-a2fae1402ceb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b23e199b-dfaa-4a35-97a8-6af5bb6682d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c2cda55-eb4b-4ea3-ba52-6eaecf9a1661"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0fc336a2-1400-43b5-8806-891c9bbefb3b"));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), "MANAGE_CLIENTS_AND_PROJECT_TAGS" },
                    { new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"), "MANAGE_VENDORS" },
                    { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), "CREATE_ANY_PROJECTS" },
                    { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), "SUGGEST_TERMS_WITHOUT_SPECIFYING_A_GLOSSARY" },
                    { new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"), "MANAGE_SERVICE_TEMPLATES" },
                    { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), "MANAGE_PROJECT_TEMPLATES" },
                    { new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"), "MANAGE_USERS" },
                    { new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"), "MANAGE_PAID_LINGUISTIC_ASSETS" },
                    { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), "MANAGE_LINGUISTIC_ASSETS_IN_ALL_PROJECTS" },
                    { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), "VIEW_ALL_PROJECTS" },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), "MANAGE_ALL_GLOSSARIES" },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), "MANAGE_ALL_TMS" },
                    { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), "MANAGE_ORDERS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), "LOCALIZATION_TEAM" },
                    { new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), "ADMINISTRATOR" },
                    { new Guid("6faf71df-2619-4373-9835-82821b31bc25"), "TALENT" },
                    { new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77"), "RESOURCE_MANAGER" },
                    { new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), "PROJECT_MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "PrivilegeId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), new Guid("98226852-ee9d-4745-8a6d-0b66c7555faa") },
                    { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), new Guid("a1d01b80-54ac-49e9-b801-a456a1a98ce0") },
                    { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), new Guid("45eab76b-e7ed-4ba7-8bf6-ad157783561a") },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), new Guid("4cf470b2-c6a2-47c5-9e50-59f4358524fe") },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"), new Guid("5e98fb19-750b-49df-9310-8100d3aa0604") },
                    { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("4698beea-891b-413c-94d2-63d14b680fd5") },
                    { new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("b3782702-74ab-43c8-86c2-b2bd1c2d91aa") },
                    { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("6433e0e5-840d-4a5b-b65d-f098f0d7ea62") },
                    { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("4ec6db11-f38b-4c8d-b46c-87d705413a3f") },
                    { new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("0d706aa0-aeff-4be5-aabd-17fb0e2402e5") },
                    { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("b75e4e4c-8510-46ec-b95b-19432ba02b2c") },
                    { new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("642c08ef-e58e-44db-977a-4fccd251d4ef") },
                    { new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("7d7e91d6-bbb1-4bbd-a659-bf03a34b717b") },
                    { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("0d003362-5d3e-4010-af7e-0a3d17a45532") },
                    { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("9e4366a2-0463-479d-929b-fe516394e1f9") },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("1763564d-4e78-4915-b128-4e592c2cef85") },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("bb8ddaf0-2073-4657-8f5f-10708bc56d5d") },
                    { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), new Guid("71111bfb-8912-482e-abfc-01650ffd29b8") },
                    { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77"), new Guid("d38aa996-1f12-4147-a797-a727cce31f6d") },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77"), new Guid("b271f340-ae1d-421a-ac61-a4d0200e3d94") },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77"), new Guid("12422b9b-9d92-4481-be66-b922ec2f24d3") },
                    { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("fdbe9202-70b0-4ed2-b3b8-944df2996e20") },
                    { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("20e78899-c286-4f3f-a410-146e2a75d1fa") },
                    { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("218204b1-77f6-409d-8f0b-8e9791759fbb") },
                    { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("def7dc94-6d2d-4f4c-85ec-2917edcc7c87") },
                    { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("e40f84b0-f960-4e6a-a4be-b12f5d90d3a8") },
                    { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("f04077ca-9133-42c6-9b58-abd9ccfe4dc2") },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("4374d1f9-96bf-42e7-a3c3-2a48ba58733c") },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("02f6fbc2-69ef-4d6d-99da-c0b4d1482a38") },
                    { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"), new Guid("6a452c8e-4c2e-4354-88c4-d5ded4c50783") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Firstname", "Gender", "Lastname", "Password", "PhoneNumber", "RoleId", "Status", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), "System", new DateTime(2023, 9, 24, 21, 28, 39, 914, DateTimeKind.Local).AddTicks(4614), "Admin", 1, "Yopmail", "$2a$11$/Ccuv/Dz0fks2yfQ/lsLU.P7xTtzPi9yl2v/rdUwiKmSNVzQYQWGy", "0333333333", new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"), 1, "System", new DateTime(2023, 9, 24, 21, 28, 39, 914, DateTimeKind.Local).AddTicks(4614), "admin.dotnetstarter@yopmail.com" });

            migrationBuilder.InsertData(
                table: "UserPrivileges",
                columns: new[] { "PrivilegeId", "UserId", "Id" },
                values: new object[,]
                {
                    { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("9c453f74-5ad3-4e4b-8af6-3b49afd3af55") },
                    { new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("b8bd577e-dc4d-4834-91ca-925693183426") },
                    { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("2a3f6622-5bfd-49e9-b89a-c36a4848516a") },
                    { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("5c691944-52a9-416c-bd6b-cb9edb0472b2") },
                    { new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("cf9d870e-1b77-44bc-a626-aef69c4fcc31") },
                    { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("124b789f-f51a-4431-afcc-8ac5acf3c405") },
                    { new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("2799ddd5-4590-4855-b1c9-b732151db597") },
                    { new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("fea9b621-65b2-4743-8bb6-d8a5440c9715") },
                    { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("25818f9a-05e3-48e6-9f0b-c0e0f42267ef") },
                    { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("33a9bda8-700b-4599-a9af-ad8d467e94e2") },
                    { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("db091d7f-b019-40e8-bc2d-cbd96a1d9fd6") },
                    { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("37a44316-b776-49d8-98c8-b9d432dc3dfe") },
                    { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"), new Guid("b45e1f57-31e1-4644-afe8-bb5045f3bed0") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("20605041-b02f-487d-9346-0d7ca10e44d9") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "RolePrivileges",
                keyColumns: new[] { "PrivilegeId", "RoleId" },
                keyValues: new object[] { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6faf71df-2619-4373-9835-82821b31bc25"));

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("d1c79973-6bc7-412f-a36a-322896caca37"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "UserPrivileges",
                keyColumns: new[] { "PrivilegeId", "UserId" },
                keyValues: new object[] { new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"), new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052") });

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("0b86be03-3108-45b2-9395-9fff73196dc7"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("28f71db9-0a42-4d46-9598-8ae23757d93c"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("3dd1ace0-2705-4506-9e5c-af0fca494249"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("6f486878-dc77-45d3-9c4e-da2754084e2d"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("7ec9f54f-785b-4044-a760-a74468e81a7e"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("8bef0e9b-3ef5-48fd-8dcf-c1314474f94f"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9192d5a9-4c14-4476-bed7-4adfaf3143a1"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("9e78bf4f-5755-4de6-a9f1-eb55e128fce3"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("b52c6097-8351-40a9-a292-d63a38fd33de"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("bb69557d-f2e0-494a-8d22-c22804365f28"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("d1c79973-6bc7-412f-a36a-322896caca37"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("ec6da46f-856f-4ba6-bcfa-f83b7b76d0dc"));

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: new Guid("f7f1930a-e9f0-4e86-aefb-80a53bac54f3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("20605041-b02f-487d-9346-0d7ca10e44d9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("86a71f44-f797-41d7-ab6e-a19cb24c6c77"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8bad9fd7-2154-4472-b251-f3fe125bb355"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed6a5f95-cdb8-471d-9018-92be865e3052"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2756e33b-7f24-452e-85fe-5a8bc3244f5e"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

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
        }
    }
}
