using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManufacturesTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufactureContact_Manufactures_ManufactureId",
                schema: "Mint",
                table: "ManufactureContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufactureContact",
                schema: "Mint",
                table: "ManufactureContact");

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("76efdb7f-a5bc-438c-a746-d61d4383af45"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("bac1cabf-cb89-479d-a4c0-8f621dd3bf67"));

            migrationBuilder.RenameTable(
                name: "ManufactureContact",
                schema: "Mint",
                newName: "ManufactureContacts",
                newSchema: "Mint");

            migrationBuilder.RenameIndex(
                name: "IX_ManufactureContact_ManufactureId",
                schema: "Mint",
                table: "ManufactureContacts",
                newName: "IX_ManufactureContacts_ManufactureId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufactureContact_ContactInformation",
                schema: "Mint",
                table: "ManufactureContacts",
                newName: "IX_ManufactureContacts_ContactInformation");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                schema: "Mint",
                table: "ManufactureContacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufactureContacts",
                schema: "Mint",
                table: "ManufactureContacts",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("65d781b0-d9bf-4fba-ae3a-f9e7c98715af"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 },
                    { new Guid("6b4298a0-8c23-48ff-a68c-55328d809e13"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "hsBE2bnpdJycXxT/d3YvOQvHvrznMBrhpO9j0e+e034=", new byte[] { 160, 4, 9, 82, 50, 163, 174, 54, 28, 181, 219, 119, 250, 116, 205, 236 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "AJ/OS0GCvU8mvtx5bHy2lBA+ikwV48YzA5TTraOUAW4=", new byte[] { 160, 4, 9, 82, 50, 163, 174, 54, 28, 181, 219, 119, 250, 116, 205, 236 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ManufactureContacts_Manufactures_ManufactureId",
                schema: "Mint",
                table: "ManufactureContacts",
                column: "ManufactureId",
                principalSchema: "Mint",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManufactureContacts_Manufactures_ManufactureId",
                schema: "Mint",
                table: "ManufactureContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManufactureContacts",
                schema: "Mint",
                table: "ManufactureContacts");

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("65d781b0-d9bf-4fba-ae3a-f9e7c98715af"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("6b4298a0-8c23-48ff-a68c-55328d809e13"));

            migrationBuilder.RenameTable(
                name: "ManufactureContacts",
                schema: "Mint",
                newName: "ManufactureContact",
                newSchema: "Mint");

            migrationBuilder.RenameIndex(
                name: "IX_ManufactureContacts_ManufactureId",
                schema: "Mint",
                table: "ManufactureContact",
                newName: "IX_ManufactureContact_ManufactureId");

            migrationBuilder.RenameIndex(
                name: "IX_ManufactureContacts_ContactInformation",
                schema: "Mint",
                table: "ManufactureContact",
                newName: "IX_ManufactureContact_ContactInformation");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                schema: "Mint",
                table: "ManufactureContact",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManufactureContact",
                schema: "Mint",
                table: "ManufactureContact",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("76efdb7f-a5bc-438c-a746-d61d4383af45"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 },
                    { new Guid("bac1cabf-cb89-479d-a4c0-8f621dd3bf67"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "dD6t4QYGsz+PXIl1hibpMYFDOzUzxlC7wo1OnL6awJc=", new byte[] { 202, 225, 72, 136, 222, 207, 49, 51, 243, 244, 165, 48, 130, 12, 240, 71 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "FsUuyNYbzjrlOMFv9fHtWLsie/F83bMPYM7G1lajX8o=", new byte[] { 202, 225, 72, 136, 222, 207, 49, 51, 243, 244, 165, 48, 130, 12, 240, 71 } });

            migrationBuilder.AddForeignKey(
                name: "FK_ManufactureContact_Manufactures_ManufactureId",
                schema: "Mint",
                table: "ManufactureContact",
                column: "ManufactureId",
                principalSchema: "Mint",
                principalTable: "Manufactures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
