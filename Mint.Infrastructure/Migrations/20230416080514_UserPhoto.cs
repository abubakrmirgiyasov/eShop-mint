using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("77900b52-bcca-49ce-90ed-c869cfb01610"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f"));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 16, 15, 5, 14, 357, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 16, 15, 5, 14, 357, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 16, 15, 5, 14, 357, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4"), new DateTime(2023, 4, 16, 15, 5, 14, 357, DateTimeKind.Local).AddTicks(9004), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "fdyxfhIShJBlhhCMe0r8kz4m3JbejjnwhAbnxZTTGUA=", 83452763423L, null, null, new byte[] { 100, 33, 202, 139, 206, 167, 116, 90, 199, 27, 194, 97, 204, 21, 217, 97 }, "User", 654000 },
                    { new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7"), new DateTime(2023, 4, 16, 15, 5, 14, 357, DateTimeKind.Local).AddTicks(3179), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "e1VMAhs5IRBSrLmgvomgYj7zZQEIqlWYa0KgoyrlJ9Q=", 89502768428L, null, null, new byte[] { 100, 33, 202, 139, 206, 167, 116, 90, 199, 27, 194, 97, 204, 21, 217, 97 }, "Абубакр", 654000 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhotoId",
                table: "Users",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Photo_PhotoId",
                table: "Users",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photo_PhotoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhotoId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5e9ba5f-76d0-44b8-922f-3fb5fbae91d4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0f0e997-2662-499a-8063-05ff5f7b0df7"));

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 13, 23, 17, 45, 780, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 13, 23, 17, 45, 780, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 13, 23, 17, 45, 780, DateTimeKind.Local).AddTicks(9594));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "Salt", "SecondName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("77900b52-bcca-49ce-90ed-c869cfb01610"), new DateTime(2023, 4, 13, 23, 17, 45, 780, DateTimeKind.Local).AddTicks(9543), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "poMZG04BgZesshDfWVtZowUV/Mn8iStrzD/LpImVbPQ=", 83452763423L, null, new byte[] { 38, 210, 36, 179, 125, 107, 241, 66, 129, 41, 206, 49, 66, 92, 164, 158 }, "User", 654000 },
                    { new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f"), new DateTime(2023, 4, 13, 23, 17, 45, 780, DateTimeKind.Local).AddTicks(1151), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "95XUclu5yxgQp0lNgSYOsAGqyXvtZxgp6ErkvUT6Ufs=", 89502768428L, null, new byte[] { 38, 210, 36, 179, 125, 107, 241, 66, 129, 41, 206, 49, 66, 92, 164, 158 }, "Абубакр", 654000 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("77900b52-bcca-49ce-90ed-c869cfb01610") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("95d4ddb1-69c9-4457-9875-e14dd81dd52f") }
                });
        }
    }
}
