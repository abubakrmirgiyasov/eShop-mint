using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DateLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("442383b8-03df-4d49-b421-43ee49a4613e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("442383b8-03df-4d49-b421-43ee49a4613e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("442383b8-03df-4d49-b421-43ee49a4613e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "LikedProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LikedProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 20, 0, 6, 55, 777, DateTimeKind.Local).AddTicks(2151));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 20, 0, 6, 55, 777, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 20, 0, 6, 55, 777, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb"), new DateTime(2023, 5, 20, 0, 6, 55, 776, DateTimeKind.Local).AddTicks(4999), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "DjCMTOR1qScVSUdleGul9WkdsuFVqpxeGJ8qsLUJ8a8=", 89502768428L, null, null, new byte[] { 236, 133, 120, 118, 9, 47, 103, 134, 188, 46, 72, 165, 228, 91, 179, 136 }, "Абубакр" },
                    { new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098"), new DateTime(2023, 5, 20, 0, 6, 55, 777, DateTimeKind.Local).AddTicks(2078), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "DOfk7LPr6Li9g823Mit/YHXPALMwWwYwSNfA27r1+h4=", 83452763423L, null, null, new byte[] { 236, 133, 120, 118, 9, 47, 103, 134, 188, 46, 72, 165, 228, 91, 179, 136 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedProducts_UserId",
                table: "LikedProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProducts_Users_UserId",
                table: "LikedProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProducts_Users_UserId",
                table: "LikedProducts");

            migrationBuilder.DropIndex(
                name: "IX_LikedProducts_UserId",
                table: "LikedProducts");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d50b66d-15c7-4b6a-82f0-13cff03923cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8e40b14e-da1a-4ad4-abff-550c8851d098"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "LikedProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LikedProducts");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 18, 18, 48, 36, 704, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 18, 18, 48, 36, 704, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 18, 18, 48, 36, 704, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("442383b8-03df-4d49-b421-43ee49a4613e"), new DateTime(2023, 5, 18, 18, 48, 36, 703, DateTimeKind.Local).AddTicks(9228), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "qnjxBq4lV1oc2Ic8FI1km46pwcJNRrIkbunb90R/4FY=", 89502768428L, null, null, new byte[] { 150, 117, 93, 175, 203, 22, 254, 69, 114, 243, 74, 224, 172, 15, 239, 237 }, "Абубакр" },
                    { new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1"), new DateTime(2023, 5, 18, 18, 48, 36, 704, DateTimeKind.Local).AddTicks(6161), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "/ztIKCjVDU4qomZ0n3/aPBcCNMChOjJbwImXPgW/GcA=", 83452763423L, null, null, new byte[] { 150, 117, 93, 175, 203, 22, 254, 69, 114, 243, 74, 224, 172, 15, 239, 237 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("442383b8-03df-4d49-b421-43ee49a4613e") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("442383b8-03df-4d49-b421-43ee49a4613e") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("949c1881-3feb-4dea-9e3f-74c03c0900d1") }
                });
        }
    }
}
