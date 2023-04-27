﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mint.Infrastructure;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230425153314_CategorySubCategoryFix")]
    partial class CategorySubCategoryFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mint.Domain.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(777)
                        .HasColumnType("nvarchar(777)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Mint.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BadgeStyle")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("BadgeText")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("ExternalLink")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("FullName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Ico")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid?>("ManufactureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManufactureId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Mint.Domain.Models.Manufacture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Mint.Domain.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Mint.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                            CreactionDate = new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(471),
                            Name = "Админ"
                        },
                        new
                        {
                            Id = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            CreactionDate = new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(496),
                            Name = "Продавец"
                        },
                        new
                        {
                            Id = new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                            CreactionDate = new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(502),
                            Name = "Покупатель"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(777)
                        .HasColumnType("nvarchar(777)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmedEmail")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("NumOfAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("PhotoId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb"),
                            CreatedDate = new DateTime(2023, 4, 25, 22, 33, 14, 279, DateTimeKind.Local).AddTicks(324),
                            DateBirth = new DateTime(2001, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
                            Email = "abubakrmirgiyasov@gmail.com",
                            FirstName = "Миргиясов",
                            Gender = "M",
                            Ip = "127.0.0.1",
                            IsActive = true,
                            IsConfirmedEmail = true,
                            LastName = "Мукимжонович",
                            NumOfAttempts = 0,
                            Password = "6iHT+PEmKAsOUpwYcQk/6knF/t1OzIT6HxSmKz3167s=",
                            Phone = 89502768428L,
                            Salt = new byte[] { 233, 49, 218, 166, 30, 169, 189, 45, 192, 22, 57, 156, 130, 175, 22, 241 },
                            SecondName = "Абубакр"
                        },
                        new
                        {
                            Id = new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f"),
                            CreatedDate = new DateTime(2023, 4, 25, 22, 33, 14, 280, DateTimeKind.Local).AddTicks(396),
                            DateBirth = new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
                            Email = "admin@mint.com",
                            FirstName = "Test",
                            Gender = "F",
                            Ip = "127.0.0.2",
                            IsActive = true,
                            IsConfirmedEmail = true,
                            NumOfAttempts = 0,
                            Password = "YqhqiAFhlMYL5OobXfzi586IP5qVlbU/wpWbCA/yrk8=",
                            Phone = 83452763423L,
                            Salt = new byte[] { 233, 49, 218, 166, 30, 169, 189, 45, 192, 22, 57, 156, 130, 175, 22, 241 },
                            SecondName = "User"
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                            UserId = new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb")
                        },
                        new
                        {
                            RoleId = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            UserId = new Guid("5aef3559-7849-409b-8b68-d9f273dea6bb")
                        },
                        new
                        {
                            RoleId = new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                            UserId = new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f")
                        },
                        new
                        {
                            RoleId = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            UserId = new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f")
                        },
                        new
                        {
                            RoleId = new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                            UserId = new Guid("4f4b2cac-c5c4-4ba3-855d-8aaebc5f4e8f")
                        });
                });

            modelBuilder.Entity("Mint.Domain.Models.Address", b =>
                {
                    b.HasOne("Mint.Domain.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mint.Domain.Models.Category", b =>
                {
                    b.HasOne("Mint.Domain.Models.Manufacture", "Manufacture")
                        .WithMany("Categories")
                        .HasForeignKey("ManufactureId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Mint.Domain.Models.SubCategory", "SubCategory")
                        .WithMany("Categories")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Manufacture");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Mint.Domain.Models.Manufacture", b =>
                {
                    b.HasOne("Mint.Domain.Models.Photo", "Photo")
                        .WithMany("Manufactures")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Mint.Domain.Models.RefreshToken", b =>
                {
                    b.HasOne("Mint.Domain.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.HasOne("Mint.Domain.Models.Photo", "Photo")
                        .WithMany("Users")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Mint.Domain.Models.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Mint.Domain.Models.UserRole", b =>
                {
                    b.HasOne("Mint.Domain.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mint.Domain.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mint.Domain.Models.Manufacture", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Navigation("Manufactures");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.Role", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.SubCategory", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
