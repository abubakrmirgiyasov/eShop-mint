using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DiscountActiveDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActiveDateUntil",
                schema: "Mint",
                table: "Discounts",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("5f33ad47-a973-418c-a6b7-08660a4bd652"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(874), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("66e835d3-7aaf-42be-9e7d-970173e4bae7"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(915), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("70298181-e41d-41a9-86c5-ac349a74af6d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(906), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("83733797-4c73-457a-874b-cba254c6d71e"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(911), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3616c928-a4d1-4dfb-a622-1d750bbb5739"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 874, DateTimeKind.Unspecified).AddTicks(7417), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6f7652b5-92de-4a44-9342-a68a4b92ff52"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 874, DateTimeKind.Unspecified).AddTicks(7456), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 874, DateTimeKind.Unspecified).AddTicks(7453), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(5826), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(5835), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("d307c97f-2ebf-4b77-a35b-f728ebaaad0d"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 872, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "CreatedDate", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("1b3ce15a-4f80-47da-96fd-27405b2130d9"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 875, DateTimeKind.Unspecified).AddTicks(9956), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 },
                    { new Guid("82bebf5a-1eb2-49c9-8b7a-402111c00f78"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 878, DateTimeKind.Unspecified).AddTicks(1060), new TimeSpan(0, 7, 0, 0, 0)), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 889, DateTimeKind.Unspecified).AddTicks(6586), new TimeSpan(0, 7, 0, 0, 0)), "yIZ+WgCyiwQuEl/9Arixva3vl0HpfMDaXIyrpR2iMtE=", new byte[] { 201, 113, 176, 250, 177, 120, 16, 200, 234, 42, 83, 148, 94, 84, 36, 234 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "CreatedDate", "Password", "Salt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 4, 29, 21, 34, 35, 888, DateTimeKind.Unspecified).AddTicks(5177), new TimeSpan(0, 7, 0, 0, 0)), "LoLZOHU0AwdnVOt3h0ALA9Yf/Fj2D6GmUG1vWaZWqlI=", new byte[] { 201, 113, 176, 250, 177, 120, 16, 200, 234, 42, 83, 148, 94, 84, 36, 234 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("1b3ce15a-4f80-47da-96fd-27405b2130d9"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("82bebf5a-1eb2-49c9-8b7a-402111c00f78"));

            migrationBuilder.DropColumn(
                name: "ActiveDateUntil",
                schema: "Mint",
                table: "Discounts");

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
        }
    }
}
