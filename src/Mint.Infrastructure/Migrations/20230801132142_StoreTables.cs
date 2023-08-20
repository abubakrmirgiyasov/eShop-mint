using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d"));

            migrationBuilder.CreateTable(
                name: "StoreReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    StoreRating = table.Column<double>(type: "float", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReviews_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "IsConfirmedPhone", "IsDeleted", "IsSeller", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "Salt", "SecondName", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96"), 0, new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, false, false, false, null, 0, "Bq4aN/qOgiCyxMReDpSevZxu8/c3a/gE5R8P0IHPh+0=", 83452763423L, null, new byte[] { 163, 228, 29, 81, 109, 88, 19, 34, 142, 193, 195, 246, 157, 115, 79, 206 }, "User", null },
                    { new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4"), 0, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, false, false, false, "Мукимжонович", 0, "8qvOdB6twb0WGEDFX1ZrGLseOjoQFVnKA+trJ7z3IsI=", 89502768428L, null, new byte[] { 163, 228, 29, 81, 109, 88, 19, 34, 142, 193, 195, 246, 157, 115, 79, 206 }, "Абубакр", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") },
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreReviews_StoreId",
                table: "StoreReviews",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReviews_UserId",
                table: "StoreReviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreReviews");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5d67e95c-7b33-4374-afe7-2c57ea0e3f96"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9eb2ffe1-51ba-434b-ac72-10beaa4306e4"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "IsConfirmedPhone", "IsDeleted", "IsSeller", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "Salt", "SecondName", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce"), 0, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, false, false, false, "Мукимжонович", 0, "xo+77cZVLwQZe0FGI1N09kWz6Kws3nsBWoC3ZroMUxI=", 89502768428L, null, new byte[] { 4, 183, 254, 185, 241, 216, 184, 64, 193, 89, 160, 83, 210, 208, 124, 64 }, "Абубакр", null },
                    { new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d"), 0, new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, false, false, false, null, 0, "CpCkf1J6+TpD/WchaJX0S3kNvY+H/7Reetixpz9pM1o=", 83452763423L, null, new byte[] { 4, 183, 254, 185, 241, 216, 184, 64, 193, 89, 160, 83, 210, 208, 124, 64 }, "User", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") },
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("61683d1c-96d6-4c8f-b320-70aff2531cce") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("851575a0-d280-4ae6-8c16-3f46ff2e424d") }
                });
        }
    }
}
