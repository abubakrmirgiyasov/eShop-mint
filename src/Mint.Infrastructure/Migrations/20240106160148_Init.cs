using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mint.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Mint");

            migrationBuilder.CreateTable(
                name: "Characteristics",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TranslateEn = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UniqueKey = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Translate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ico = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    BadgeText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BadgeStyle = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DefaultLink = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Mint",
                        principalTable: "Photos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Manufactures",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufactures_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Mint",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    WorkHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    IsPhysical = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Mint",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(777)", maxLength: 777, nullable: true),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSeller = table.Column<bool>(type: "bit", nullable: false),
                    NumOfAttempts = table.Column<int>(type: "int", nullable: false),
                    ConfirmationCode = table.Column<int>(type: "int", nullable: false),
                    IsConfirmedEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmedPhone = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Mint",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTags",
                schema: "Mint",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTags", x => new { x.TagId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryTags_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Mint",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Mint",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    DefaultLink = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Mint",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufactureCategories",
                schema: "Mint",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureCategories", x => new { x.CategoryId, x.ManufactureId });
                    table.ForeignKey(
                        name: "FK_ManufactureCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Mint",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufactureCategories_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalSchema: "Mint",
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManufactureTags",
                schema: "Mint",
                columns: table => new
                {
                    ManufactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactureTags", x => new { x.TagId, x.ManufactureId });
                    table.ForeignKey(
                        name: "FK_ManufactureTags_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalSchema: "Mint",
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufactureTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Mint",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Sku = table.Column<int>(type: "int", nullable: false),
                    Gtin = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    AdminComment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShowOnHomePage = table.Column<bool>(type: "bit", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 7, nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 7, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeTax = table.Column<bool>(type: "bit", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryMinDay = table.Column<int>(type: "int", nullable: false),
                    DeliveryMaxDay = table.Column<int>(type: "int", nullable: false),
                    ManufactureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Mint",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalSchema: "Mint",
                        principalTable: "Manufactures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreAddresses",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreAddresses_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Mint",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategory",
                schema: "Mint",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategory", x => new { x.StoreId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_StoreCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Mint",
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreCategory_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Mint",
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreTags",
                schema: "Mint",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTags", x => new { x.StoreId, x.TagId });
                    table.ForeignKey(
                        name: "FK_StoreTags_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Mint",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Mint",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Mint",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcceptLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Mint",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreReviews",
                schema: "Mint",
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
                        principalSchema: "Mint",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreReviews_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Mint",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_addresses",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(999)", maxLength: 999, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_addresses_countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Mint",
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_addresses_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Mint",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "Mint",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Mint",
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Mint",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommonCharacteristics",
                schema: "Mint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Guaranty = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonCharacteristics_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Mint",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCharacteristics",
                schema: "Mint",
                columns: table => new
                {
                    CharacteristicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharacteristics", x => new { x.ProductId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_ProductCharacteristics_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalSchema: "Mint",
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCharacteristics_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Mint",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                schema: "Mint",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => new { x.ProductId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "Mint",
                        principalTable: "Photos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Mint",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                schema: "Mint",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Mint",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "Mint",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "countries",
                columns: new[] { "Id", "CountryCode", "Name", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("3616c928-a4d1-4dfb-a622-1d750bbb5739"), "RU-ru", "Россия", null },
                    { new Guid("6f7652b5-92de-4a44-9342-a68a4b92ff52"), "KZ-kz", "Қазақстан", null },
                    { new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "TJ-tj", "Тоҷикистон", null }
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "roles",
                columns: new[] { "Id", "Name", "TranslateEn", "UniqueKey", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"), "Продавец", "SELLER", "SELLER", null },
                    { new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"), "Админ", "ADMIN", "ADMIN", null },
                    { new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"), "Покупатель", "BUYER", "BUYER", null }
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "users",
                columns: new[] { "Id", "ConfirmationCode", "DateBirth", "Description", "FirstName", "Gender", "Ip", "IsActive", "IsConfirmedEmail", "IsConfirmedPhone", "IsDeleted", "IsSeller", "LastName", "NumOfAttempts", "Password", "PhotoId", "Salt", "SecondName", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 0, new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test User Почта: test@gmail.com Телефон: 83452763423", "Test", "Female", "127.0.0.2", true, true, false, false, false, null, 0, "QqefH9FC5R94xCagcA3UaOEttLZ2nGYhWv6rYZiVro4=", null, new byte[] { 228, 182, 29, 160, 199, 116, 218, 220, 105, 173, 241, 60, 153, 148, 49, 204 }, "User", null },
                    { new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 0, new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428", "Миргиясов", "Male", "127.0.0.1", true, true, false, false, false, "Мукимжонович", 0, "dk33SGOv38YCrAY9E/BkCRINffJ8ersiXZE/bT+8hPk=", null, new byte[] { 228, 182, 29, 160, 199, 116, 218, 220, 105, 173, 241, 60, 153, 148, 49, 204 }, "Абубакр", null }
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "contacts",
                columns: new[] { "Id", "ContactInformation", "CountryCode", "Type", "UpdateDateTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f33ad47-a973-418c-a6b7-08660a4bd652"), "+79502768428", "RU", "Phone", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0") },
                    { new Guid("66e835d3-7aaf-42be-9e7d-970173e4bae7"), "+73452763423", "RU", "Phone", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572") },
                    { new Guid("70298181-e41d-41a9-86c5-ac349a74af6d"), "abubakrmirgiyasov@gmail.com", null, "Email", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0") },
                    { new Guid("83733797-4c73-457a-874b-cba254c6d71e"), "admin@mint.com", null, "Email", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572") }
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "user_addresses",
                columns: new[] { "Id", "City", "CountryId", "Description", "FullAddress", "FullName", "Street", "UpdateDateTime", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("29df3dac-70c2-4a19-8a3b-56b724e64004"), "Новосибирск", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Россия, г. Новосибирск, ул. Заллесского, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Заллесского", null, new Guid("2448250c-0fc7-464b-9872-ce6a17de0572"), 635600 },
                    { new Guid("e29a0622-f90b-4072-ae7e-1e9cadc1d0da"), "Худжанд", new Guid("e8fc7423-4c93-4465-bfb4-8db45abb1296"), "full address for custom user", "Таджикистан, г. Худжанд, ул. Тиллокон, дом 12 кв. 49", "#e256100b-0328-4a16-924a-76bdf987e6a0 - FirstName:Миргиясов SecondName:Абубакр", "ул. Тиллокон", null, new Guid("e256100b-0328-4a16-924a-76bdf987e6a0"), 735700 }
                });

            migrationBuilder.InsertData(
                schema: "Mint",
                table: "user_roles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"), new Guid("2448250c-0fc7-464b-9872-ce6a17de0572") },
                    { new Guid("22a99751-e418-49c5-ac4e-ce221dd7ae0d"), new Guid("e256100b-0328-4a16-924a-76bdf987e6a0") },
                    { new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"), new Guid("2448250c-0fc7-464b-9872-ce6a17de0572") },
                    { new Guid("68c2f692-2f9a-4d0e-9d89-9c2ff7f0409b"), new Guid("e256100b-0328-4a16-924a-76bdf987e6a0") },
                    { new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"), new Guid("2448250c-0fc7-464b-9872-ce6a17de0572") },
                    { new Guid("7582ed34-eb4a-4628-a7e7-971af7379ec8"), new Guid("e256100b-0328-4a16-924a-76bdf987e6a0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DefaultLink",
                schema: "Mint",
                table: "Categories",
                column: "DefaultLink",
                unique: true,
                filter: "[DefaultLink] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PhotoId",
                schema: "Mint",
                table: "Categories",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTags_CategoryId",
                schema: "Mint",
                table: "CategoryTags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonCharacteristics_ProductId",
                schema: "Mint",
                table: "CommonCharacteristics",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_ContactInformation",
                schema: "Mint",
                table: "contacts",
                column: "ContactInformation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_UserId",
                schema: "Mint",
                table: "contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureCategories_ManufactureId",
                schema: "Mint",
                table: "ManufactureCategories",
                column: "ManufactureId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_PhotoId",
                schema: "Mint",
                table: "Manufactures",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_Website",
                schema: "Mint",
                table: "Manufactures",
                column: "Website",
                unique: true,
                filter: "[Website] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ManufactureTags_ManufactureId",
                schema: "Mint",
                table: "ManufactureTags",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharacteristics_CharacteristicId",
                schema: "Mint",
                table: "ProductCharacteristics",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_PhotoId",
                schema: "Mint",
                table: "ProductPhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Mint",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Gtin",
                schema: "Mint",
                table: "Products",
                column: "Gtin",
                unique: true,
                filter: "[Gtin] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureId",
                schema: "Mint",
                table: "Products",
                column: "ManufactureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                schema: "Mint",
                table: "Products",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                schema: "Mint",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_UserId",
                schema: "Mint",
                table: "refresh_tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UniqueKey",
                schema: "Mint",
                table: "roles",
                column: "UniqueKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreAddresses_StoreId",
                schema: "Mint",
                table: "StoreAddresses",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategory_CategoryId",
                schema: "Mint",
                table: "StoreCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReviews_StoreId",
                schema: "Mint",
                table: "StoreReviews",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReviews_UserId",
                schema: "Mint",
                table: "StoreReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Email",
                schema: "Mint",
                table: "Stores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Phone",
                schema: "Mint",
                table: "Stores",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PhotoId",
                schema: "Mint",
                table: "Stores",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Url",
                schema: "Mint",
                table: "Stores",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreTags_TagId",
                schema: "Mint",
                table: "StoreTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                schema: "Mint",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_addresses_CountryId",
                schema: "Mint",
                table: "user_addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_addresses_UserId",
                schema: "Mint",
                table: "user_addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_UserId",
                schema: "Mint",
                table: "user_roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_PhotoId",
                schema: "Mint",
                table: "users",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTags",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "CommonCharacteristics",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "ManufactureCategories",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "ManufactureTags",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "ProductCharacteristics",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "ProductPhotos",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "ProductTags",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "refresh_tokens",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "StoreAddresses",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "StoreCategory",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "StoreReviews",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "StoreTags",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "SubCategories",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "user_addresses",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Characteristics",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "users",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Manufactures",
                schema: "Mint");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "Mint");
        }
    }
}
