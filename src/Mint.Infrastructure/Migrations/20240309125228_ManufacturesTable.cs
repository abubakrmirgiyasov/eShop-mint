using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManufacturesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manufactures_Email",
                schema: "Mint",
                table: "Manufactures");

            migrationBuilder.DropIndex(
                name: "IX_Manufactures_Phone",
                schema: "Mint",
                table: "Manufactures");

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("3b00adf1-7d8e-4807-9689-a908b9a570af"));

            migrationBuilder.DeleteData(
                schema: "Mint",
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: new Guid("65054825-14a7-4dec-999b-a1c44b3bbf9a"));

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Mint",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Mint",
                table: "Manufactures");

            migrationBuilder.CreateTable(
                name: "ManufactureContact",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufactureContact_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalSchema: "Mint",
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_Name",
                schema: "Mint",
                table: "Manufactures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureContact_ContactInformation",
                schema: "Mint",
                table: "ManufactureContact",
                column: "ContactInformation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureContact_ManufactureId",
                schema: "Mint",
                table: "ManufactureContact",
                column: "ManufactureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufactureContact",
                schema: "Mint");

            migrationBuilder.DropIndex(
                name: "IX_Manufactures_Name",
                schema: "Mint",
                table: "Manufactures");

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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Mint",
                table: "Manufactures",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Phone",
                schema: "Mint",
                table: "Manufactures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "UserAddresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("3b00adf1-7d8e-4807-9689-a908b9a570af"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 },
                    { new Guid("65054825-14a7-4dec-999b-a1c44b3bbf9a"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 }
                });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "58NdVVPnzKxTpNLkVpckY7H8Ryx0GkyDLwZxtVSWo5Q=", new byte[] { 95, 28, 78, 92, 203, 155, 133, 43, 69, 244, 5, 142, 137, 50, 20, 42 } });

            migrationBuilder.UpdateData(
                schema: "Mint",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "SGJrnay7gOtCmX544c8mQWk0tyVvb+UwTU7vqUxiFpE=", new byte[] { 95, 28, 78, 92, 203, 155, 133, 43, 69, 244, 5, 142, 137, 50, 20, 42 } });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_Email",
                schema: "Mint",
                table: "Manufactures",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_Phone",
                schema: "Mint",
                table: "Manufactures",
                column: "Phone",
                unique: true);
        }
    }
}
