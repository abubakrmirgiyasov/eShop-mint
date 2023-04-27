using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategorySubCategoryPhotoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb"));

            migrationBuilder.DropColumn(
                name: "Ico",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Ico",
                table: "SubCategories",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Categories",
                type: "uniqueidentifier",
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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PhotoId",
                table: "Categories",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Photos_PhotoId",
                table: "Categories",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Photos_PhotoId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PhotoId",
                table: "Categories");

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
                name: "Ico",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Ico",
                table: "Categories",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f"), new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(396), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "YqhqiAFhlMYL5OobXfzi586IP5qVlbU/wpWbCA/yrk8=", 83452763423L, null, null, new byte[] { 233, 49, 218, 166, 30, 169, 189, 45, 192, 22, 57, 156, 130, 175, 22, 241 }, "User" },
                    { new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb"), new DateTime(2023, 4, 25, 22, 33, 14, 279, DateTimeKind.Local).AddTicks(324), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "6iHT+PEmKAsOUpwYcQk/6knF/t1OzIT6HxSmKz3167s=", 89502768428L, null, null, new byte[] { 233, 49, 218, 166, 30, 169, 189, 45, 192, 22, 57, 156, 130, 175, 22, 241 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb") }
                });
        }
    }
}
