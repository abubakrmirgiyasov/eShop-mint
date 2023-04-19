﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mint.Infrastructure;

#nullable disable

namespace Mint.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            CreactionDate = new DateTime(2023, 4, 19, 22, 20, 1, 32, DateTimeKind.Local).AddTicks(7012),
                            Name = "Админ"
                        },
                        new
                        {
                            Id = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            CreactionDate = new DateTime(2023, 4, 19, 22, 20, 1, 32, DateTimeKind.Local).AddTicks(7018),
                            Name = "Продавец"
                        },
                        new
                        {
                            Id = new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                            CreactionDate = new DateTime(2023, 4, 19, 22, 20, 1, 32, DateTimeKind.Local).AddTicks(7020),
                            Name = "Покупатель"
                        });
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
                            Id = new Guid("fb1f9922-69e9-4537-8d9f-5686151f8287"),
                            CreatedDate = new DateTime(2023, 4, 19, 22, 20, 1, 32, DateTimeKind.Local).AddTicks(1860),
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
                            Password = "Vzrp1yhhCpm2u/tvollJ104HMX6lJPgpnFWDxAFQ73U=",
                            Phone = 89502768428L,
                            Salt = new byte[] { 99, 98, 147, 193, 111, 12, 161, 195, 77, 113, 186, 66, 180, 169, 7, 73 },
                            SecondName = "Абубакр"
                        },
                        new
                        {
                            Id = new Guid("b16c3630-123f-4535-8327-5e75b9db7eab"),
                            CreatedDate = new DateTime(2023, 4, 19, 22, 20, 1, 32, DateTimeKind.Local).AddTicks(6996),
                            DateBirth = new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
                            Email = "admin@mint.com",
                            FirstName = "Test",
                            Gender = "F",
                            Ip = "127.0.0.2",
                            IsActive = true,
                            IsConfirmedEmail = true,
                            NumOfAttempts = 0,
                            Password = "BXm1v5Vf3/XAQfMYU4EpfuVDc9cabDqn1eoqpzBZOdE=",
                            Phone = 83452763423L,
                            Salt = new byte[] { 99, 98, 147, 193, 111, 12, 161, 195, 77, 113, 186, 66, 180, 169, 7, 73 },
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
                            UserId = new Guid("fb1f9922-69e9-4537-8d9f-5686151f8287")
                        },
                        new
                        {
                            RoleId = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            UserId = new Guid("fb1f9922-69e9-4537-8d9f-5686151f8287")
                        },
                        new
                        {
                            RoleId = new Guid("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                            UserId = new Guid("b16c3630-123f-4535-8327-5e75b9db7eab")
                        },
                        new
                        {
                            RoleId = new Guid("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                            UserId = new Guid("b16c3630-123f-4535-8327-5e75b9db7eab")
                        },
                        new
                        {
                            RoleId = new Guid("4d442669-abe7-4726-af0f-5734879a113c"),
                            UserId = new Guid("b16c3630-123f-4535-8327-5e75b9db7eab")
                        });
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

            modelBuilder.Entity("Mint.Domain.Models.Photo", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.Role", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mint.Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
