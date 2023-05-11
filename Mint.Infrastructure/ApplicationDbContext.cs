using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Manufacture> Manufactures { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<SubCategory> SubCategories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Store> Stores { get; set; }

    public DbSet<ProductPhoto> ProductPhotos { get; set; }

    public DbSet<CommonCharacteristic> CommonCharacteristics { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<LikedProduct> LikedProducts { get; set; }

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

        builder.Entity<Store>()
            .HasIndex(x => x.Url)
            .IsUnique(true);

        builder.Entity<Product>()
            .HasIndex(x => x.Sku)
            .IsUnique(true);

        builder.Entity<UserRole>()
            .HasKey(x => new
            {
                x.RoleId,
                x.UserId,
            });

        builder.Entity<ProductPhoto>()
            .HasKey(x => new
            {
                x.ProductId,
                x.PhotoId,
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

        builder.Entity<User>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Manufacture>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Manufactures)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Category>()
            .HasOne(x => x.SubCategory)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.SubCategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Category>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Product>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Product>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Product>()
            .HasOne(x => x.Store)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CommonCharacteristic>()
            .HasOne(x => x.Product)
            .WithMany(x => x.CommonCharacteristics)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Product>()
            .HasOne(x => x.Discount)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.DiscountId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Storage>()
            .HasOne(x => x.Product)
            .WithMany(x => x.Storages)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Storage>()
            .HasOne(x => x.Store)
            .WithMany(x => x.Storages)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<Order>()
            .HasOne(x => x.Store)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Order>()
            .HasOne(x => x.Product)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<LikedProduct>()
            .HasOne(x => x.Product)
            .WithMany(x => x.LikedProducts)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.SetNull);

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
                DateBirth = new DateTime(2001, 12, 5),
                IsActive = true,
                IsConfirmedEmail = true,
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
                DateBirth = new DateTime(2003, 10, 1),
                Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
                IsActive = true,
                IsConfirmedEmail = true,
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
