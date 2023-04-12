﻿using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        builder.Entity<User>()
            .HasIndex(x => x.Phone)
            .IsUnique(true);

        builder.Entity<UserRole>()
            .HasKey(x => new
            {
                x.RoleId,
                x.UserId,
            });

        builder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RefreshToken>()
            .HasOne(x => x.User)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        var salt = new Hasher().GetSalt();

        var users = new User[]
        {
            new User()
            {
                FirstName = "Миргиясов",
                SecondName = "Абубакр",
                LastName = "Мукимжонович",
                Email = "abubakrmirgiyasov@gmail.com",
                Phone = 89502768428,
                Ip = "127.0.0.1",
                Password = new Hasher().GetHash("AbuakrMirgiyasov@))!M", salt),
                NumOfAttempts = 0,
                Salt = salt,
                Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
                Gender = "M",
                IsActive = true,
                IsConfirmedEmail = true,
                ZipCode = 654000,
                CreatedDate = DateTime.Now,
            },
            new User()
            {
                FirstName = "Test",
                SecondName = "User",
                Email = "admin@mint.com",
                Phone = 83452763423,
                Ip = "127.0.0.2",
                Password = new Hasher().GetHash("test_1", salt),
                NumOfAttempts = 0,
                Salt = salt,
                Gender = "F",
                Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
                IsActive = true,
                IsConfirmedEmail = true,
                ZipCode = 654000,
                CreatedDate = DateTime.Now,
            },
        };

        var roles = new Role[]
        {
            new Role
            {
                Id = Guid.Parse("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                Name = Constants.ADMIN,
                CreactionDate = DateTime.Now
            },
            new Role
            {
                Id = Guid.Parse("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                Name = Constants.SELLER,
                CreactionDate = DateTime.Now
            },
            new Role
            {
                Id = Guid.Parse("4d442669-abe7-4726-af0f-5734879a113c"),
                Name = Constants.BUYER,
                CreactionDate = DateTime.Now
            },
        };

        var userRoles = new UserRole[]
        {
            new UserRole { UserId = users[0].Id, RoleId = roles[0].Id, }, 
            new UserRole { UserId = users[0].Id, RoleId = roles[1].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[0].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[1].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[2].Id, },
        };

        builder.Entity<User>().HasData(users);
        builder.Entity<Role>().HasData(roles);
        builder.Entity<UserRole>().HasData(userRoles);
    }
}
