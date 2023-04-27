using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategorySubCategoryFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories");

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
                name: "CategoryId",
                table: "SubCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoryId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubCategoryId",
                table: "Categories",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SubCategories_SubCategoryId",
                table: "Categories",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubCategories_SubCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubCategoryId",
                table: "Categories");

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
                name: "SubCategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "SubCategories",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
