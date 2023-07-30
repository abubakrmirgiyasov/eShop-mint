using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Identity;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin;
using Mint.Domain.Common;

namespace Mint.Infrastructure;

/// <summary>
/// Identity Application Db Context
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
	/// Constructor
	/// </summary>
	/// <param name="options"></param>
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    /// <summary>
    /// Users Table
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Roles Table
    /// </summary>
    public DbSet<Role> Roles { get; set; }

    /// <summary>
    /// Photos Table
    /// </summary>
    public DbSet<Photo> Photos { get; set; }

    /// <summary>
    /// User Roles Table
    /// </summary>
    public DbSet<UserRole> UserRoles { get; set; }

    /// <summary>
    /// User Addresses Table
    /// </summary>
    public DbSet<UserAddress> UserAddresses { get; set; }

    /// <summary>
    /// Products Table
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Product Photos Table
    /// </summary>
    public DbSet<ProductPhoto> ProductPhotos { get; set; }

    /// <summary>
    /// Tags Table
    /// </summary>
    public DbSet<Tag> Tags { get; set; }

    /// <summary>
    /// Product Tags Table
    /// </summary>
    public DbSet<ProductTag> ProductTags { get; set; }

    /// <summary>
    /// Categories Table
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Sub Categories Table
    /// </summary>
    public DbSet<SubCategory> SubCategories { get; set; }

    /// <summary>
    /// Categories Tag Table
    /// </summary>
    public DbSet<CategoryTag> CategoryTags { get; set; }

    /// <summary>
    /// Manufactures Table
    /// </summary>
    public DbSet<Manufacture> Manufactures { get; set; }

    /// <summary>
    /// Common Characteristics Table
    /// </summary>
    public DbSet<CommonCharacteristic> CommonCharacteristics { get; set; }

    /// <summary>
    /// Characteristics Table
    /// </summary>
    public DbSet<Characteristic> Characteristics { get; set; }

    /// <summary>
    /// Product Characteristics Table
    /// </summary>
    public DbSet<ProductCharacteristic> ProductCharacteristics { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        builder.Entity<User>()
            .HasIndex(x => x.Phone)
            .IsUnique(true);

        builder.Entity<Role>()
            .HasIndex(x => x.UniqueKey)
            .IsUnique(true);

        builder.Entity<Product>()
            .HasIndex(x => x.Sku)
            .IsUnique(true);

        builder.Entity<Product>()
            .HasIndex(x => x.Gtin)
            .IsUnique(true);

        builder.Entity<Manufacture>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        builder.Entity<Manufacture>()
            .HasIndex(x => x.Phone)
            .IsUnique(true);

        builder.Entity<Manufacture>()
            .HasIndex(x => x.Website)
            .IsUnique(true);

        builder.Entity<Category>()
            .HasIndex(x => x.DefaultLink)
            .IsUnique(true);

        builder.Entity<ProductTag>()
            .HasKey(x => new
            {
                x.ProductId,
                x.TagId,
            });

        builder.Entity<ProductPhoto>()
            .HasKey(x => new
            {
                x.ProductId,
                x.PhotoId,
            });

        builder.Entity<CategoryTag>()
            .HasKey(x => new
            {
                x.TagId,
                x.CategoryId,
            });

        builder.Entity<ProductCharacteristic>()
            .HasKey(x => new
            {
                x.ProductId,
                x.CharacteristicId,
            });

        builder.Entity<UserRole>()
            .HasKey(x => new
            {
                x.RoleId,
                x.UserId,
            });

        builder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RefreshToken>()
            .HasOne(x => x.User)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<User>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<UserAddress>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProductTag>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductTag>()
            .HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Product>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Manufacture>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Manufactures)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<SubCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CategoryTag>()
            .HasOne(x => x.Category)
            .WithMany(x => x.CategoryTags)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CategoryTag>()
            .HasOne(x => x.Tag)
            .WithMany(x => x.CategoryTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductCharacteristic>()
            .HasOne(x => x.Characteristic)
            .WithMany(x => x.ProductCharacteristics)
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductCharacteristic>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductCharacteristics)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        var salt = new Hasher().GetSalt();

        var users = new User[]
        {
            new User()
            {
                Id = Guid.NewGuid(),
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
                DateBirth = new DateTime(2001, 12, 5),
                IsActive = true,
                IsConfirmedEmail = true,
            },
            new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                SecondName = "User",
                Email = "admin@mint.com",
                Phone = 83452763423,
                Ip = "127.0.0.2",
                Password = new Hasher().GetHash("test_1", salt),
                NumOfAttempts = 0,
                Salt = salt,
                Gender = "F",
                DateBirth = new DateTime(2003, 10, 1),
                Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
                IsActive = true,
                IsConfirmedEmail = true,
            },
        };

        var roles = new Role[]
        {
            new Role
            {
                Id = Guid.Parse("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
                Name = Constants.ADMIN,
                TranslateEn = nameof(Constants.ADMIN),
                UniqueKey = nameof(Constants.ADMIN),
            },
            new Role
            {
                Id = Guid.Parse("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
                Name = Constants.SELLER,
                TranslateEn = nameof(Constants.SELLER),
                UniqueKey = nameof(Constants.SELLER),
            },
            new Role
            {
                Id = Guid.Parse("4d442669-abe7-4726-af0f-5734879a113c"),
                Name = Constants.BUYER,
                TranslateEn = nameof(Constants.BUYER),
                UniqueKey = nameof(Constants.BUYER),
            },
        };

        var userRoles = new UserRole[]
        {
            new UserRole { UserId = users[0].Id, RoleId = roles[0].Id, },
            new UserRole { UserId = users[0].Id, RoleId = roles[1].Id, },
            new UserRole { UserId = users[0].Id, RoleId = roles[2].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[0].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[1].Id, },
            new UserRole { UserId = users[1].Id, RoleId = roles[2].Id, },
        };

        builder.Entity<User>().HasData(users);
        builder.Entity<Role>().HasData(roles);
        builder.Entity<UserRole>().HasData(userRoles);
    }
}
