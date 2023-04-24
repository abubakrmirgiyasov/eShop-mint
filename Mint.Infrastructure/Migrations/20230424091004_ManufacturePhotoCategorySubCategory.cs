using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManufacturePhotoCategorySubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9815a679-1d78-48ec-87e0-d033faa42e72") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9815a679-1d78-48ec-87e0-d033faa42e72") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9815a679-1d78-48ec-87e0-d033faa42e72"));

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Photos",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Photos",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Photos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<string>(
                name: "FileExtension",
                table: "Photos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BadgeText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BadgeStyle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ExternalLink = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Ico = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufactures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Manufactures_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_PhotoId",
                table: "Manufactures",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");

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

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Photos",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "FileExtension",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 20, 23, 8, 57, 803, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 20, 23, 8, 57, 803, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 20, 23, 8, 57, 803, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5"), new DateTime(2023, 4, 20, 23, 8, 57, 803, DateTimeKind.Local).AddTicks(5356), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "MgY+0XLsmjFFtEItA90DaUSzxZ4CER3Na3EWTCkn3AY=", 83452763423L, null, null, new byte[] { 31, 96, 237, 36, 22, 195, 145, 65, 92, 177, 36, 130, 171, 204, 255, 209 }, "User" },
                    { new Guid("9815a679-1d78-48ec-87e0-d033faa42e72"), new DateTime(2023, 4, 20, 23, 8, 57, 802, DateTimeKind.Local).AddTicks(5996), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "m/DNPgoHWhv3ffEcMJw0SCMfq2UEwUo42pEjB8QGaHY=", 89502768428L, null, null, new byte[] { 31, 96, 237, 36, 22, 195, 145, 65, 92, 177, 36, 130, 171, 204, 255, 209 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9815a679-1d78-48ec-87e0-d033faa42e72") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("22bbd09e-e3f9-40b8-ba0e-0f9eb825dfc5") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9815a679-1d78-48ec-87e0-d033faa42e72") }
                });
        }
    }
}
