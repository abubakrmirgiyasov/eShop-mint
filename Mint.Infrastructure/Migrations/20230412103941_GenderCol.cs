using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GenderCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0e05800e-ad5d-4d3e-b378-22578568825b") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0e05800e-ad5d-4d3e-b378-22578568825b") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0e05800e-ad5d-4d3e-b378-22578568825b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18"));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 12, 17, 39, 41, 66, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 12, 17, 39, 41, 66, DateTimeKind.Local).AddTicks(3372));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 12, 17, 39, 41, 66, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "Salt", "SecondName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("2bed4009-f525-4ae0-a479-98eba30371e7"), new DateTime(2023, 4, 12, 17, 39, 41, 66, DateTimeKind.Local).AddTicks(3317), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "olgTZVj+xO/pmouwW4kcQ4KdPYcY10uwS8Iiu6Xn0kA=", 83452763423L, null, new byte[] { 243, 50, 146, 115, 39, 226, 170, 184, 214, 207, 242, 10, 152, 62, 44, 35 }, "User", 654000 },
                    { new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680"), new DateTime(2023, 4, 12, 17, 39, 41, 65, DateTimeKind.Local).AddTicks(3272), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "5WS6bLhz5Ap8fdnH4dwC8aPs4WYAA6Kf31ex2QN50os=", 89502768428L, null, new byte[] { 243, 50, 146, 115, 39, 226, 170, 184, 214, 207, 242, 10, 152, 62, 44, 35 }, "Абубакр", 654000 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2bed4009-f525-4ae0-a479-98eba30371e7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2bed4009-f525-4ae0-a479-98eba30371e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9aa188ab-f4f7-452d-88a7-cebd6c0a9680"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 7, 18, 43, 14, 203, DateTimeKind.Local).AddTicks(6729));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 7, 18, 43, 14, 203, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 7, 18, 43, 14, 203, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "FirstName", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "RoleId", "Salt", "SecondName", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0e05800e-ad5d-4d3e-b378-22578568825b"), new DateTime(2023, 4, 7, 18, 43, 14, 202, DateTimeKind.Local).AddTicks(9728), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "127.0.0.1", true, true, "Мукимжонович", 0, "adoJGFdbXwjcip7bseReSz7+D49HBbtHYLUMfHbRlkk=", 89502768428L, null, new byte[] { 18, 124, 164, 130, 156, 86, 198, 212, 178, 87, 233, 15, 244, 110, 236, 161 }, "Абубакр", 654000 },
                    { new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18"), new DateTime(2023, 4, 7, 18, 43, 14, 203, DateTimeKind.Local).AddTicks(6697), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "127.0.0.2", true, true, null, 0, "ekMEW2CO7YwGUky52vgA2KSRCJsym7nPlyYtDPMTabo=", 83452763423L, null, new byte[] { 18, 124, 164, 130, 156, 86, 198, 212, 178, 87, 233, 15, 244, 110, 236, 161 }, "User", 654000 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0e05800e-ad5d-4d3e-b378-22578568825b") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0e05800e-ad5d-4d3e-b378-22578568825b") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("b522d6c3-223d-4ce6-993c-6746489f0b18") }
                });
        }
    }
}
