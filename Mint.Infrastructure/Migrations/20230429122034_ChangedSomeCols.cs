using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSomeCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("6e2826d8-6efa-4569-9632-64441aea395b") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("6e2826d8-6efa-4569-9632-64441aea395b") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6e2826d8-6efa-4569-9632-64441aea395b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56"));

            migrationBuilder.DropColumn(
                name: "BadgeText",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "BadgeStyle",
                table: "Categories",
                newName: "DefaultLink");

            migrationBuilder.AddColumn<string>(
                name: "BadgeStyle",
                table: "SubCategories",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BadgeText",
                table: "SubCategories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 29, 19, 20, 34, 172, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 29, 19, 20, 34, 172, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 29, 19, 20, 34, 172, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f"), new DateTime(2023, 4, 29, 19, 20, 34, 172, DateTimeKind.Local).AddTicks(7611), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "SoAVpDzMXuCQuWasNALamw4yAzPjqkQgALkvwf2tj5A=", 83452763423L, null, null, new byte[] { 168, 176, 100, 159, 199, 84, 86, 234, 174, 12, 236, 133, 7, 185, 152, 216 }, "User" },
                    { new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617"), new DateTime(2023, 4, 29, 19, 20, 34, 172, DateTimeKind.Local).AddTicks(2460), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "C3P4aoHiK6HztaYEEoPsWOBtcP623wSWA7AXxeoVTPI=", 89502768428L, null, null, new byte[] { 168, 176, 100, 159, 199, 84, 86, 234, 174, 12, 236, 133, 7, 185, 152, 216 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("544e2b4b-4202-4591-8714-49b18b4b5d5f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("684999d3-ddac-4ba3-a10b-479a9a85d617"));

            migrationBuilder.DropColumn(
                name: "BadgeStyle",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "BadgeText",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "DefaultLink",
                table: "Categories",
                newName: "BadgeStyle");

            migrationBuilder.AddColumn<string>(
                name: "BadgeText",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 26, 23, 22, 53, 401, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 26, 23, 22, 53, 401, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 26, 23, 22, 53, 401, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("6e2826d8-6efa-4569-9632-64441aea395b"), new DateTime(2023, 4, 26, 23, 22, 53, 400, DateTimeKind.Local).AddTicks(4094), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "m4ydAcswS4kZmmpeLWSyQMlLbEFtU5gebFwVfnKatbA=", 89502768428L, null, null, new byte[] { 125, 10, 204, 166, 145, 81, 0, 227, 37, 81, 69, 102, 11, 45, 83, 0 }, "Абубакр" },
                    { new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56"), new DateTime(2023, 4, 26, 23, 22, 53, 401, DateTimeKind.Local).AddTicks(3407), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "eWRyMEdOqsWe8m/qtC3f8IUSSwz1jUpviBAYNwfn0Vg=", 83452763423L, null, null, new byte[] { 125, 10, 204, 166, 145, 81, 0, 227, 37, 81, 69, 102, 11, 45, 83, 0 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("6e2826d8-6efa-4569-9632-64441aea395b") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("6e2826d8-6efa-4569-9632-64441aea395b") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("ebb3c50f-4a80-49fa-a60a-33bef0807d56") }
                });
        }
    }
}
