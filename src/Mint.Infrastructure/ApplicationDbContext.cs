using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Identity;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin;
using Mint.Domain.Models.Stores;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Common;
using Mint.Domain.Common;
using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Admin.Tags;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure;

/// <summary>
/// Application Database Instance
/// </summary>
/// <param name="options"></param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    /// <summary>
    /// Users Table
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Roles Table
    /// </summary>
    public DbSet<Role> Roles => Set<Role>();

    /// <summary>
    /// User Roles Table
    /// </summary>
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    /// <summary>
    /// User Addresses Table
    /// </summary>
    public DbSet<UserAddress> UserAddresses => Set<UserAddress>();

    /// <summary>
    /// Contacts Table
    /// </summary>
    public DbSet<Contact> Contacts => Set<Contact>();

    /// <summary>
    /// Photos Table
    /// </summary>
    public DbSet<Photo> Photos => Set<Photo>();
    
    /// <summary>
    /// Products Table
    /// </summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Product Photos Table
    /// </summary>
    public DbSet<ProductPhoto> ProductPhotos => Set<ProductPhoto>();

    /// <summary>
    /// Tags Table
    /// </summary>
    public DbSet<Tag> Tags => Set<Tag>();

    /// <summary>
    /// Product Tags Table
    /// </summary>
    public DbSet<ProductTag> ProductTags => Set<ProductTag>();

    /// <summary>
    /// Categories Table
    /// </summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>
    /// Sub Categories Table
    /// </summary>
    public DbSet<SubCategory> SubCategories => Set<SubCategory>();

    /// <summary>
    /// Categories Tag Table
    /// </summary>
    public DbSet<CategoryTag> CategoryTags => Set<CategoryTag>();

    /// <summary>
    /// Common Characteristics Table
    /// </summary>
    public DbSet<CommonCharacteristic> CommonCharacteristics => Set<CommonCharacteristic>();

    /// <summary>
    /// Characteristics Table
    /// </summary>
    public DbSet<Characteristic> Characteristics => Set<Characteristic>();

    /// <summary>
    /// Product Characteristics Table
    /// </summary>
    public DbSet<ProductCharacteristic> ProductCharacteristics => Set<ProductCharacteristic>();

    /// <summary>
    /// Product Categories Table
    /// </summary>
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    /// <summary>
    /// Stores Table
    /// </summary>
    public DbSet<Store> Stores => Set<Store>();

    /// <summary>
    /// Store Addresses Table
    /// </summary>
    public DbSet<StoreAddress> StoreAddresses => Set<StoreAddress>();

    /// <summary>
    /// Store Tags Table
    /// </summary>
    public DbSet<StoreTag> StoreTags => Set<StoreTag>();

    /// <summary>
    /// Store Reviews Table
    /// </summary>
    public DbSet<StoreReview> StoreReviews => Set<StoreReview>();

    /// <summary>
    /// Manufactures Table
    /// </summary>
    public DbSet<Manufacture> Manufactures => Set<Manufacture>();

    /// <summary>
    /// ManufactureCategories Table
    /// </summary>
    public DbSet<ManufactureCategory> ManufactureCategories => Set<ManufactureCategory>();

    /// <summary>
    /// Manufacture Tags Table
    /// </summary>
    public DbSet<ManufactureTag> ManufactureTags => Set<ManufactureTag>();

    /// <summary>
    /// Manufacture Contacts Table
    /// </summary>
    public DbSet<ManufactureContact> ManufactureContacts => Set<ManufactureContact>();

    /// <summary>
    /// Countries Table
    /// </summary>
    public DbSet<Country> Countries => Set<Country>();

    /// <summary>
    /// Units Table
    /// </summary>
    public DbSet<Unit> Units => Set<Unit>();

    /// <summary>
    /// Discounts Table
    /// </summary>
    public DbSet<Discount> Discounts => Set<Discount>();

    /// <summary>
    /// Product Reviews Table
    /// </summary>
    public DbSet<ProductReview> ProductReviews => Set<ProductReview>();

    /// <summary>
    /// Product Review Photos Table
    /// </summary>
    public DbSet<ProductReviewPhoto> ProductReviewPhotos => Set<ProductReviewPhoto>();

    /// <summary>
    /// Storages Table
    /// </summary>
    public DbSet<Storage> Storages => Set<Storage>();

    /// <summary>
    /// Store Contacts Table
    /// </summary>
    public DbSet<StoreContact> StoreContacts => Set<StoreContact>();

    /// <summary>
    /// Refresh Tokens Table
    /// </summary>
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .HasDefaultSchema(SchemeNames.Mint.ToString())
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<ProductTag>()
            .HasKey(x => new
            {
                x.ProductId,
                x.TagId,
            });

        builder.Entity<ManufactureCategory>()
            .HasKey(x => new 
            {
                x.CategoryId,
                x.ManufactureId,
            });

        builder.Entity<ManufactureTag>()
            .HasKey(x => new
            {
                x.TagId,
                x.ManufactureId,
            });
        
        builder.Entity<ManufactureCategory>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.ManufactureCategories)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ManufactureCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.ManufactureCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SubCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ManufactureTag>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.ManufactureTags)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ManufactureTag>()
            .HasOne(x => x.Tag)
            .WithMany(x => x.ManufactureTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
