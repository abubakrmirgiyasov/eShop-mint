using Microsoft.EntityFrameworkCore;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<object> Users { get; set; }

    public DbSet<object> Roles { get; set; }

    public DbSet<object> UserRoles { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Photo> Photos { get; set; }

    public DbSet<object> RefreshTokens { get; set; }

    public DbSet<Manufacture> Manufactures { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<SubCategory> SubCategories { get; set; }

    public DbSet<object> Products { get; set; }

    public DbSet<Store> Stores { get; set; }

    public DbSet<object> ProductPhotos { get; set; }

    public DbSet<object> CommonCharacteristics { get; set; }

    public DbSet<Discount> Discounts { get; set; }

    public DbSet<LikedProduct> LikedProducts { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<ReviewPhoto> ReviewPhotos { get; set; }

    public DbSet<Pdf> Pdfs { get; set; }

    public DbSet<object> ProductAttributes { get; set; }

    public DbSet<object> Attributes { get; set; }

    public DbSet<object> Characteristics { get; set; }

    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }

    public DbSet<StoreCategory> StoreCategories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<User>()
        //    .HasIndex(x => x.Email)
        //    .IsUnique(true);

        //builder.Entity<User>()
        //    .HasIndex(x => x.Phone)
        //    .IsUnique(true);

        //builder.Entity<Store>()
        //    .HasIndex(x => x.Url)
        //    .IsUnique(true);

        //builder.Entity<Product>()
        //    .HasIndex(x => x.Sku)
        //    .IsUnique(true);

        //builder.Entity<Category>()
        //    .HasIndex(x => x.DefaultLink)
        //    .IsUnique(true);

        //builder.Entity<Domain.Models.Attribute>()
        //    .HasIndex(x => x.Name)
        //    .IsUnique(true);

        //builder.Entity<UserRole>()
        //    .HasKey(x => new
        //    {
        //        x.RoleId,
        //        x.UserId,
        //    });

        //builder.Entity<ProductPhoto>()
        //    .HasKey(x => new
        //    {
        //        x.ProductId,
        //        x.PhotoId,
        //    });

        //builder.Entity<OrderProduct>()
        //    .HasKey(x => new
        //    {
        //        x.ProductId,
        //        x.OrderId,
        //    });

        //builder.Entity<ReviewPhoto>()
        //    .HasKey(x => new
        //    {
        //        x.ReviewId,
        //        x.PhotoId
        //    });

        //builder.Entity<ProductAttribute>()
        //    .HasKey(x => new
        //    {
        //        x.ProductId,
        //        x.AttributeId,
        //    });

        //builder.Entity<CategoryAttribute>()
        //    .HasKey(x => new
        //    {
        //        x.AttributeId,
        //        x.CategoryId,
        //    });

        //builder.Entity<StoreCategory>()
        //    .HasKey(x => new
        //    {
        //        x.StoreId,
        //        x.CategoryId,
        //    });

        //builder.Entity<UserRole>()
        //    .HasOne(x => x.User)
        //    .WithMany(x => x.UserRoles)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<UserRole>()
        //    .HasOne(x => x.Role)
        //    .WithMany(x => x.UserRoles)
        //    .HasForeignKey(x => x.RoleId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<RefreshToken>()
        //    .HasOne(x => x.User)
        //    .WithMany(x => x.RefreshTokens)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.NoAction);

        //builder.Entity<User>()
        //    .HasOne(x => x.Photo)
        //    .WithMany(x => x.Users)
        //    .HasForeignKey(x => x.PhotoId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Manufacture>()
        //    .HasOne(x => x.Photo)
        //    .WithMany(x => x.Manufactures)
        //    .HasForeignKey(x => x.PhotoId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Category>()
        //    .HasOne(x => x.SubCategory)
        //    .WithMany(x => x.Categories)
        //    .HasForeignKey(x => x.SubCategoryId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Category>()
        //    .HasOne(x => x.Manufacture)
        //    .WithMany(x => x.Categories)
        //    .HasForeignKey(x => x.ManufactureId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Product>()
        //    .HasOne(x => x.Category)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.CategoryId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Product>()
        //    .HasOne(x => x.Manufacture)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.ManufactureId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Product>()
        //    .HasOne(x => x.Store)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.StoreId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<ProductPhoto>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.ProductPhotos)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<ProductPhoto>()
        //    .HasOne(x => x.Photo)
        //    .WithMany(x => x.ProductPhotos)
        //    .HasForeignKey(x => x.PhotoId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<CommonCharacteristic>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.CommonCharacteristics)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Product>()
        //    .HasOne(x => x.Discount)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.DiscountId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Storage>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.Storages)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<Storage>()
        //    .HasOne(x => x.Store)
        //    .WithMany(x => x.Storages)
        //    .HasForeignKey(x => x.StoreId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<OrderProduct>()
        //    .HasOne(x => x.Store)
        //    .WithMany(x => x.OrderProducts)
        //    .HasForeignKey(x => x.StoreId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<OrderProduct>()
        //    .HasOne(x => x.Order)
        //    .WithMany(x => x.OrderProducts)
        //    .HasForeignKey(x => x.OrderId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<OrderProduct>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.OrderProducts)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<LikedProduct>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.LikedProducts)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Order>()
        //    .HasOne(x => x.Address)
        //    .WithMany(x => x.Orders)
        //    .HasForeignKey(x => x.AddressId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Review>()
        //    .HasOne(x => x.User)
        //    .WithMany(x => x.Reviews)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<Review>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.Reviews)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //builder.Entity<ReviewPhoto>()
        //    .HasOne(x => x.Review)
        //    .WithMany(x => x.ReviewPhotos)
        //    .HasForeignKey(x => x.ReviewId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<ReviewPhoto>()
        //    .HasOne(x => x.Photo)
        //    .WithMany(x => x.ReviewPhotos)
        //    .HasForeignKey(x => x.PhotoId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<LikedProduct>()
        //    .HasOne(x => x.User)
        //    .WithMany(x => x.LikedProducts)
        //    .HasForeignKey(x => x.UserId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<Product>()
        //    .HasOne(x => x.Characteristic)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.CharacteristicId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<ProductAttribute>()
        //    .HasOne(x => x.Product)
        //    .WithMany(x => x.ProductAttributes)
        //    .HasForeignKey(x => x.ProductId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<CategoryAttribute>()
        //    .HasOne(x => x.Attribute)
        //    .WithMany(x => x.CategoryAttributes)
        //    .HasForeignKey(x => x.AttributeId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<StoreCategory>()
        //    .HasOne(x => x.Category)
        //    .WithMany(x => x.StoreCategories)
        //    .HasForeignKey(x => x.CategoryId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<StoreCategory>()
        //    .HasOne(x => x.Store)
        //    .WithMany(x => x.StoreCategories)
        //    .HasForeignKey(x => x.StoreId)
        //    .OnDelete(DeleteBehavior.Cascade);

        ////builder.Entity<Pdf>()

        //var salt = new Hasher().GetSalt();

        //var users = new User[]
        //{
        //    new User()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Миргиясов",
        //        SecondName = "Абубакр",
        //        LastName = "Мукимжонович",
        //        Email = "abubakrmirgiyasov@gmail.com",
        //        Phone = 89502768428,
        //        Ip = "127.0.0.1",
        //        Password = new Hasher().GetHash("AbuakrMirgiyasov@))!M", salt),
        //        NumOfAttempts = 0,
        //        Salt = salt,
        //        Description = "Миргиясов Абубакр Почта: abubakrmirgiyasov@gmail.com Телефон: 89502768428",
        //        Gender = "M",
        //        DateBirth = new DateTime(2001, 12, 5),
        //        IsActive = true,
        //        IsConfirmedEmail = true,
        //    },
        //    new User()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Test",
        //        SecondName = "User",
        //        Email = "admin@mint.com",
        //        Phone = 83452763423,
        //        Ip = "127.0.0.2",
        //        Password = new Hasher().GetHash("test_1", salt),
        //        NumOfAttempts = 0,
        //        Salt = salt,
        //        Gender = "F",
        //        DateBirth = new DateTime(2003, 10, 1),
        //        Description = "Test User Почта: test@gmail.com Телефон: 83452763423",
        //        IsActive = true,
        //        IsConfirmedEmail = true,
        //    },
        //};

        //var roles = new Role[]
        //{
        //    new Role
        //    {
        //        Id = Guid.Parse("77a6e9b4-64b8-46f0-998d-f01dd0b5b2b4"),
        //        Name = Constants.ADMIN,
        //    },
        //    new Role
        //    {
        //        Id = Guid.Parse("8d8d8618-c897-48d4-bedc-83ba3db4b7e1"),
        //        Name = Constants.SELLER,
        //    },
        //    new Role
        //    {
        //        Id = Guid.Parse("4d442669-abe7-4726-af0f-5734879a113c"),
        //        Name = Constants.BUYER,
        //    },
        //};

        //var stores = new Store[]
        //{
        //    new Store()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Mint",
        //        Url = "mint",
        //        Country = "test",
        //        City = "test",
        //        Street = "test",
        //        ZipCode = 12345,
        //        IsOwnStorage = true,
        //        UserId = users[1].Id, // users[0].Id,
        //        AddressDescription = "test",
        //    }
        //};

        //var subCategory = new SubCategory[]
        //{
        //    new SubCategory()
        //    {
        //        Id = Guid.NewGuid(),
        //        DisplayOrder = 1,
        //        Name = "Test",
        //        Ico = "ri-home-line",
        //        BadgeText = "test",
        //        BadgeStyle = "Primary",
        //    },
        //};

        //var categories = new Category[]
        //{
        //    new Category()
        //    {
        //        Id = Guid.NewGuid(),
        //        DisplayOrder = 1,
        //        Name = "Test Child",
        //        ExternalLink = "test-child",
        //        DefaultLink = "test-child",
        //        FullName = "Test child",
        //        SubCategoryId = subCategory[0].Id,
        //    }
        //};


        //var storeCategories = new StoreCategory[]
        //{
        //    new StoreCategory()
        //    {
        //        StoreId = stores[0].Id, CategoryId = categories[0].Id,
        //    }
        //};

        //var userRoles = new UserRole[]
        //{
        //    new UserRole { UserId = users[0].Id, RoleId = roles[0].Id, },
        //    new UserRole { UserId = users[0].Id, RoleId = roles[1].Id, },
        //    new UserRole { UserId = users[0].Id, RoleId = roles[2].Id, },
        //    new UserRole { UserId = users[1].Id, RoleId = roles[0].Id, },
        //    new UserRole { UserId = users[1].Id, RoleId = roles[1].Id, },
        //    new UserRole { UserId = users[1].Id, RoleId = roles[2].Id, },
        //};

        //builder.Entity<User>().HasData(users);
        //builder.Entity<Role>().HasData(roles);
        //builder.Entity<UserRole>().HasData(userRoles);
        //builder.Entity<Store>().HasData(stores);
        //builder.Entity<Category>().HasData(categories);
        //builder.Entity<SubCategory>().HasData(subCategory);
        //builder.Entity<StoreCategory>().HasData(storeCategories);
    }
}
