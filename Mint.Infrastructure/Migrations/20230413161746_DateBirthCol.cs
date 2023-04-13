using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DateBirthCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "Users");

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
    }
}
