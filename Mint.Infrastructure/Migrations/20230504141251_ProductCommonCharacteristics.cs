using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductCommonCharacteristics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CommonCharacteristic_CommonCharacteristicId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CommonCharacteristicId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommonCharacteristic",
                table: "CommonCharacteristic");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e"));

            migrationBuilder.DropColumn(
                name: "CommonCharacteristicId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "CommonCharacteristic",
                newName: "CommonCharacteristics");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "CommonCharacteristics",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommonCharacteristics",
                table: "CommonCharacteristics",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 4, 21, 12, 51, 141, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 4, 21, 12, 51, 141, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 4, 21, 12, 51, 141, DateTimeKind.Local).AddTicks(824));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41"), new DateTime(2023, 5, 4, 21, 12, 51, 141, DateTimeKind.Local).AddTicks(758), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "T28BarUA+x4K3cLxhpx5PxFHoM5L8aveF3pJInLh2ds=", 83452763423L, null, null, new byte[] { 215, 173, 147, 80, 168, 118, 36, 215, 56, 130, 73, 229, 59, 66, 88, 185 }, "User" },
                    { new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18"), new DateTime(2023, 5, 4, 21, 12, 51, 140, DateTimeKind.Local).AddTicks(670), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "Gqx5tmMgdFne5tj6agmucr+BT/1E3jnFNMPyb5XZhWs=", 89502768428L, null, null, new byte[] { 215, 173, 147, 80, 168, 118, 36, 215, 56, 130, 73, 229, 59, 66, 88, 185 }, "Абубакр" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonCharacteristics_ProductId",
                table: "CommonCharacteristics",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonCharacteristics_Products_ProductId",
                table: "CommonCharacteristics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonCharacteristics_Products_ProductId",
                table: "CommonCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommonCharacteristics",
                table: "CommonCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_CommonCharacteristics_ProductId",
                table: "CommonCharacteristics");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c3d5eaf-8fb6-4472-a2b4-948b903abb41"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("426e8bee-bf07-4eeb-aa9f-025adce5bf18"));

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CommonCharacteristics");

            migrationBuilder.RenameTable(
                name: "CommonCharacteristics",
                newName: "CommonCharacteristic");

            migrationBuilder.AddColumn<Guid>(
                name: "CommonCharacteristicId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommonCharacteristic",
                table: "CommonCharacteristic",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 3, 19, 13, 29, 445, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 3, 19, 13, 29, 445, DateTimeKind.Local).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                column: "CreactionDate",
                value: new DateTime(2023, 5, 3, 19, 13, 29, 445, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateBirth", "Description", "Email", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "LastName", "NumOfAttempts", "Password", "Phone", "PhotoId", "RoleId", "Salt", "SecondName" },
                values: new object[,]
                {
                    { new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296"), new DateTime(2023, 5, 3, 19, 13, 29, 444, DateTimeKind.Local).AddTicks(8338), new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "abubakrmirgiyasov@gmail.com", "Миргиясов", "M", "127.0.0.1", true, true, "Мукимжонович", 0, "CRAsWrpMbE2GK6klE0OfF0MckC+QCIuAs5ac5ICE1ds=", 89502768428L, null, null, new byte[] { 15, 238, 250, 163, 101, 76, 115, 63, 182, 52, 232, 50, 59, 78, 142, 45 }, "Абубакр" },
                    { new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e"), new DateTime(2023, 5, 3, 19, 13, 29, 445, DateTimeKind.Local).AddTicks(3561), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "admin@mint.com", "Test", "F", "127.0.0.2", true, true, null, 0, "LHeIsFn5XlNF1JEcbqOdMSuDiG58G0qLuYefPjuNQlg=", 83452763423L, null, null, new byte[] { 15, 238, 250, 163, 101, 76, 115, 63, 182, 52, 232, 50, 59, 78, 142, 45 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4d442669-abe7-4726-af0f-5734879a113c"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296") },
                    { new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("2f6c05ac-20c6-49f2-82df-f641c5fda296") },
                    { new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"), new Guid("3ceebb32-8679-474e-bd30-15a9bf740e9e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommonCharacteristicId",
                table: "Products",
                column: "CommonCharacteristicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CommonCharacteristic_CommonCharacteristicId",
                table: "Products",
                column: "CommonCharacteristicId",
                principalTable: "CommonCharacteristic",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
