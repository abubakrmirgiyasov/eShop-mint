using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DiscountUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategory_Categories_CategoryId",
                schema: "Mint",
                table: "StoreCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategory_Stores_StoreId",
                schema: "Mint",
                table: "StoreCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategory",
                schema: "Mint",
                table: "StoreCategory");

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("2cdddcab-5b41-40a8-9403-003df1e8d791"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("3eb5919a-e677-4512-861b-47d61d1bf3e4"));

            migrationBuilder.RenameTable(
                name: "StoreCategory",
                schema: "Mint",
                newName: "StoreCategories",
                newSchema: "Mint");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategory_CategoryId",
                schema: "Mint",
                table: "StoreCategories",
                newName: "IX_StoreCategories_CategoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Mint",
                table: "Discounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategories",
                schema: "Mint",
                table: "StoreCategories",
                columns: new[] { "StoreId", "CategoryId" });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("5f33ad47-a973-418c-a6b7-08660a4bd652"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(1281), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("66e835d3-7aaf-42be-9e7d-970173e4bae7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(1308), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("70298181-e41d-41a9-86c5-ac349a74af6d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(1300), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("83733797-4c73-457a-874b-cba254c6d71e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(1304), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3616c928-a4d1-4dfb-a622-1d750bbb5739"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 765, DateTimeKind.Unspecified).AddTicks(7682), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f7652b5-92de-4a44-9342-a68a4b92ff52"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 765, DateTimeKind.Unspecified).AddTicks(7706), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 765, DateTimeKind.Unspecified).AddTicks(7702), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(6485), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(6464), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 766, DateTimeKind.Unspecified).AddTicks(6509), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("d307c97f-2ebf-4b77-a35b-f728ebaaad0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 763, DateTimeKind.Unspecified).AddTicks(9922), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "CreatedDate", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("e0dbf7a5-1dac-4e2d-8bec-6ef445da5219"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 769, DateTimeKind.Unspecified).AddTicks(2681), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 },
                    { new Guid("e284e992-f866-4a7a-a787-3bbec2fa018c"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 767, DateTimeKind.Unspecified).AddTicks(591), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 778, DateTimeKind.Unspecified).AddTicks(8205), new TimeSpan(0, 7, 0, 0, 0)), "8a5i64K2U18csfk/F3LwI00221v8wfCbWZ70Qz8NM8Q=", new byte[] { 236, 173, 73, 248, 186, 199, 172, 217, 254, 139, 176, 186, 91, 246, 132, 176 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 15, 22, 51, 777, DateTimeKind.Unspecified).AddTicks(4984), new TimeSpan(0, 7, 0, 0, 0)), "hVIXNO0TZREz3zebVhW4+2PDL9A3LB6+zv0OnBrX6C8=", new byte[] { 236, 173, 73, 248, 186, 199, 172, 217, 254, 139, 176, 186, 91, 246, 132, 176 } });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_UserId",
                schema: "Mint",
                table: "Discounts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Users_UserId",
                schema: "Mint",
                table: "Discounts",
                column: "UserId",
                principalSchema: "Mint",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategories_Categories_CategoryId",
                schema: "Mint",
                table: "StoreCategories",
                column: "CategoryId",
                principalSchema: "Mint",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategories_Stores_StoreId",
                schema: "Mint",
                table: "StoreCategories",
                column: "StoreId",
                principalSchema: "Mint",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Users_UserId",
                schema: "Mint",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategories_Categories_CategoryId",
                schema: "Mint",
                table: "StoreCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategories_Stores_StoreId",
                schema: "Mint",
                table: "StoreCategories");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_UserId",
                schema: "Mint",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategories",
                schema: "Mint",
                table: "StoreCategories");

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("e0dbf7a5-1dac-4e2d-8bec-6ef445da5219"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("e284e992-f866-4a7a-a787-3bbec2fa018c"));

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Mint",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "StoreCategories",
                schema: "Mint",
                newName: "StoreCategory",
                newSchema: "Mint");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategories_CategoryId",
                schema: "Mint",
                table: "StoreCategory",
                newName: "IX_StoreCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategory",
                schema: "Mint",
                table: "StoreCategory",
                columns: new[] { "StoreId", "CategoryId" });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("5f33ad47-a973-418c-a6b7-08660a4bd652"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(9332), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("66e835d3-7aaf-42be-9e7d-970173e4bae7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(9384), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("70298181-e41d-41a9-86c5-ac349a74af6d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(9371), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("83733797-4c73-457a-874b-cba254c6d71e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3616c928-a4d1-4dfb-a622-1d750bbb5739"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(2277), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f7652b5-92de-4a44-9342-a68a4b92ff52"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 598, DateTimeKind.Unspecified).AddTicks(2329), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 599, DateTimeKind.Unspecified).AddTicks(7532), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 599, DateTimeKind.Unspecified).AddTicks(7508), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 599, DateTimeKind.Unspecified).AddTicks(7547), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("d307c97f-2ebf-4b77-a35b-f728ebaaad0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 594, DateTimeKind.Unspecified).AddTicks(1951), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "CreatedDate", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("2cdddcab-5b41-40a8-9403-003df1e8d791"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 602, DateTimeKind.Unspecified).AddTicks(6425), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 },
                    { new Guid("3eb5919a-e677-4512-861b-47d61d1bf3e4"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 600, DateTimeKind.Unspecified).AddTicks(4357), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 615, DateTimeKind.Unspecified).AddTicks(949), new TimeSpan(0, 7, 0, 0, 0)), "vDwJR/fM1amO2PD0KCwuA2947X+jos2sNXtV9dhtXMg=", new byte[] { 56, 178, 139, 211, 198, 245, 120, 94, 48, 161, 71, 137, 25, 204, 205, 34 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 12, 19, 48, 16, 614, DateTimeKind.Unspecified).AddTicks(4748), new TimeSpan(0, 7, 0, 0, 0)), "T3ljSMyLakDcChSvC2bYP3/91j5BJu9J9bll+vmue74=", new byte[] { 56, 178, 139, 211, 198, 245, 120, 94, 48, 161, 71, 137, 25, 204, 205, 34 } });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategory_Categories_CategoryId",
                schema: "Mint",
                table: "StoreCategory",
                column: "CategoryId",
                principalSchema: "Mint",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategory_Stores_StoreId",
                schema: "Mint",
                table: "StoreCategory",
                column: "StoreId",
                principalSchema: "Mint",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
