using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManufactureCategoryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufactures_Categories_CategoryId",
                table: "Manufactures");

            migrationBuilder.DropIndex(
                name: "IX_Manufactures_CategoryId",
                table: "Manufactures");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Manufactures");

            migrationBuilder.AddColumn<Guid>(
                name: "ManufactureId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ManufactureId",
                table: "Categories",
                column: "ManufactureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Manufactures_ManufactureId",
                table: "Categories",
                column: "ManufactureId",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Manufactures_ManufactureId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ManufactureId",
                table: "Categories");

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

            migrationBuilder.DropColumn(
                name: "ManufactureId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Manufactures",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 16, 10, 3, 880, DateTimeKind.Local).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 16, 10, 3, 880, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 24, 16, 10, 3, 880, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb"), new DateTime(2023, 4, 24, 16, 10, 3, 880, DateTimeKind.Local).AddTicks(3), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "fP+TZIuJUDBSi9sCl6rSSLBMcuJuM97dSS6bK+Aa0Fc=", 83452763423L, null, null, new byte[] { 241, 236, 163, 155, 150, 91, 138, 4, 27, 226, 67, 86, 54, 85, 71, 190 }, "User" },
                    { new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b"), new DateTime(2023, 4, 24, 16, 10, 3, 878, DateTimeKind.Local).AddTicks(5409), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "u8g7kg3AVwYXMcIQkuK7l12CtvankA3cbskzD3AAu+Y=", 89502768428L, null, null, new byte[] { 241, 236, 163, 155, 150, 91, 138, 4, 27, 226, 67, 86, 54, 85, 71, 190 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("6815eb20-ec7d-425f-a7a5-5cf35a499ccb") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("751f7274-0e16-43ce-8c76-f4ab354a0b3b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_CategoryId",
                table: "Manufactures",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manufactures_Categories_CategoryId",
                table: "Manufactures",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
