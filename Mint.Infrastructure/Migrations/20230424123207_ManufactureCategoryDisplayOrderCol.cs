using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManufactureCategoryDisplayOrderCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("a998da2e-0387-4732-b526-c688990dbc46") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("a998da2e-0387-4732-b526-c688990dbc46") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a998da2e-0387-4732-b526-c688990dbc46"));

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Manufactures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 19, 32, 7, 647, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 19, 32, 7, 647, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 19, 32, 7, 647, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96"), new DateTime(2023, 4, 24, 19, 32, 7, 646, DateTimeKind.Local).AddTicks(3510), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "vMIP3aYGfKU7CpKH2F7luFVIje3eV6cvLJAQj74RC3c=", 89502768428L, null, null, new byte[] { 244, 225, 82, 95, 190, 217, 191, 83, 163, 20, 0, 89, 13, 129, 141, 235 }, "Абубакр" },
                    { new Guid("4826ce21-9756-4749-a56b-65f465cddb5e"), new DateTime(2023, 4, 24, 19, 32, 7, 647, DateTimeKind.Local).AddTicks(877), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "d982Bp+hO/0TDjTB7J9hAn9mhsVe2U3a0yryhRFkBoE=", 83452763423L, null, null, new byte[] { 244, 225, 82, 95, 190, 217, 191, 83, 163, 20, 0, 89, 13, 129, 141, 235 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4826ce21-9756-4749-a56b-65f465cddb5e") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ef61428-e734-4a8f-957d-39d91ffd3f96"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4826ce21-9756-4749-a56b-65f465cddb5e"));

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 17, 20, 52, 383, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 17, 20, 52, 383, DateTimeKind.Local).AddTicks(2737));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 17, 20, 52, 383, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8"), new DateTime(2023, 4, 24, 17, 20, 52, 383, DateTimeKind.Local).AddTicks(2655), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "hXVtm1tFCUVxh4dUzlLRdIyK/FtTAPYTAvCKjbc1IiY=", 83452763423L, null, null, new byte[] { 171, 65, 197, 245, 30, 196, 228, 141, 96, 206, 233, 166, 161, 69, 237, 146 }, "User" },
                    { new Guid("a998da2e-0387-4732-b526-c688990dbc46"), new DateTime(2023, 4, 24, 17, 20, 52, 381, DateTimeKind.Local).AddTicks(9563), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "Tg9FAOzadnfSiAJEiDp5XuwZpjRC6xmN8OK6YiDXs34=", 89502768428L, null, null, new byte[] { 171, 65, 197, 245, 30, 196, 228, 141, 96, 206, 233, 166, 161, 69, 237, 146 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("a998da2e-0387-4732-b526-c688990dbc46") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9dd28ead-5606-4be0-b246-05e967f80cd8") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("a998da2e-0387-4732-b526-c688990dbc46") }
                });
        }
    }
}
