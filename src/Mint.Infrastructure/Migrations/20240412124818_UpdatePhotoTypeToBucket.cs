using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhotoTypeToBucket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("9df2ce0d-c81c-462f-8f1c-dfeead332a17"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("b7169285-78f5-4bcd-ac76-9bff2ee6b61e"));

            migrationBuilder.RenameColumn(
                name: "FileType",
                schema: "Mint",
                table: "Photos",
                newName: "Bucket");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "Mint",
                table: "Photos",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Bucket",
                schema: "Mint",
                table: "Photos",
                newName: "FileType");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                schema: "Mint",
                table: "Photos",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("5f33ad47-a973-418c-a6b7-08660a4bd652"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(595), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("66e835d3-7aaf-42be-9e7d-970173e4bae7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(624), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("70298181-e41d-41a9-86c5-ac349a74af6d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(616), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("83733797-4c73-457a-874b-cba254c6d71e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(620), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3616c928-a4d1-4dfb-a622-1d750bbb5739"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 41, DateTimeKind.Unspecified).AddTicks(6500), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f7652b5-92de-4a44-9342-a68a4b92ff52"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 41, DateTimeKind.Unspecified).AddTicks(6535), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 41, DateTimeKind.Unspecified).AddTicks(6532), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(6515), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(6493), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 42, DateTimeKind.Unspecified).AddTicks(6526), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("d307c97f-2ebf-4b77-a35b-f728ebaaad0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 39, DateTimeKind.Unspecified).AddTicks(5675), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "CreatedDate", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("9df2ce0d-c81c-462f-8f1c-dfeead332a17"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 45, DateTimeKind.Unspecified).AddTicks(3451), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 },
                    { new Guid("b7169285-78f5-4bcd-ac76-9bff2ee6b61e"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 43, DateTimeKind.Unspecified).AddTicks(1448), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 52, DateTimeKind.Unspecified).AddTicks(7210), new TimeSpan(0, 7, 0, 0, 0)), "v9qwDKGBPupu/a6FOJ1jzQ+VKfcq8bEgfg87volggbw=", new byte[] { 32, 16, 64, 216, 21, 72, 79, 244, 70, 242, 189, 28, 185, 39, 213, 63 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 9, 23, 47, 2, 52, DateTimeKind.Unspecified).AddTicks(1815), new TimeSpan(0, 7, 0, 0, 0)), "3hYhFVCJI1pkRSsyiLcNkjqqGhueHtxVaU96zDGt3Rw=", new byte[] { 32, 16, 64, 216, 21, 72, 79, 244, 70, 242, 189, 28, 185, 39, 213, 63 } });
        }
    }
}
