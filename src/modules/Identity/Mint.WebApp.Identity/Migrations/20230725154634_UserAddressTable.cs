using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.WebApp.Identity.Migrations
{
    /// <inheritdoc />
    public partial class UserAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0952b37d-fa8a-442e-ba83-98e333745edd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd"));

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(777)", maxLength: 777, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "IsConfirmedPhone", "IsDeleted", "IsSeller", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "Salt", "SecondName", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc"), 0, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, false, false, false, "Мукимжонович", 0, "ByUB+pnOaEo7CRn1UunjhS1Iza01xWxQV3l3BCri1YI=", 89502768428L, null, new byte[] { 10, 170, 60, 97, 174, 223, 124, 210, 127, 20, 211, 247, 172, 55, 42, 83 }, "Абубакр", null },
                    { new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d"), 0, new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, false, false, false, null, 0, "tJn4Z0YgP0PkwCNf/lmSVPuGcoALOSOt1ztfGvJ1wWA=", 83452763423L, null, new byte[] { 10, 170, 60, 97, 174, 223, 124, 210, 127, 20, 211, 247, 172, 55, 42, 83 }, "User", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") },
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0602b2b9-9c30-4f0d-a150-212f0d1772bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("42712038-3fac-4944-b3ad-88b24f09dd0d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "IsConfirmedPhone", "IsDeleted", "IsSeller", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "Salt", "SecondName", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0952b37d-fa8a-442e-ba83-98e333745edd"), 0, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, false, false, false, "Мукимжонович", 0, "53cfX0TrWxsQRCGc3pFtMbMCKvRT1RGj5EeDzl312bQ=", 89502768428L, null, new byte[] { 173, 115, 44, 30, 165, 121, 25, 118, 250, 102, 28, 72, 193, 211, 123, 22 }, "Абубакр", null },
                    { new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd"), 0, new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, false, false, false, null, 0, "siEA3mJheUKN2hNhfmd8YcrByNWQgnCJ4n062FIZqP8=", 83452763423L, null, new byte[] { 173, 115, 44, 30, 165, 121, 25, 118, 250, 102, 28, 72, 193, 211, 123, 22 }, "User", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") },
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("0952b37d-fa8a-442e-ba83-98e333745edd") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3034ae6c-ec23-496f-baab-7cf528d4edfd") }
                });
        }
    }
}
