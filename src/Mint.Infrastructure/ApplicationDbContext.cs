using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Identity;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin;
using Mint.Domain.Models.Stores;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Common;
using Mint.Domain.Common;

namespace Mint.Infrastructure;

/// <summary>
/// Application Db Context
/// </summary>
/// <remarks>
/// Constructor
/// </remarks>
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
    public DbSet<Photo> Photos { get; set; }
    
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

    /// <summary>
    /// Stores Table
    /// </summary>
    public DbSet<Store> Stores { get; set; }

    /// <summary>
    /// Store Addresses Table
    /// </summary>
    public DbSet<StoreAddress> StoreAddresses { get; set; }

    /// <summary>
    /// Store Tags Table
    /// </summary>
    public DbSet<StoreTag> StoreTags { get; set; }

    /// <summary>
    /// Store Reviews Table
    /// </summary>
    public DbSet<StoreReview> StoreReviews { get; set; }

    /// <summary>
    /// Manufactures Table
    /// </summary>
    public DbSet<Manufacture> Manufactures { get; set; }

    /// <summary>
    /// ManufactureCategories Table
    /// </summary>
    public DbSet<ManufactureCategory> ManufactureCategories { get; set; }

    /// <summary>
    /// Manufacture Tags Table
    /// </summary>
    public DbSet<ManufactureTag> ManufactureTags { get; set; }

    /// <summary>
    /// Manufacture Contacts Table
    /// </summary>
    public DbSet<ManufactureContact> ManufactureContacts => Set<ManufactureContact>();

    /// <summary>
    /// Countries Table
    /// </summary>
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .HasDefaultSchema(SchemeNames.Mint.ToString())
            .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<Product>()
            .HasIndex(x => x.Sku)
            .IsUnique(true);

        builder.Entity<Product>()
            .HasIndex(x => x.Gtin)
            .IsUnique(true);

        builder.Entity<Manufacture>()
            .HasIndex(x => x.Website)
            .IsUnique(true);

        builder.Entity<Store>()
            .HasIndex(x => x.Url)
            .IsUnique(true);

        builder.Entity<Store>()
            .HasIndex(x => x.Email)
            .IsUnique(true);

        builder.Entity<Store>()
            .HasIndex(x => x.Phone)
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

        builder.Entity<ProductCharacteristic>()
            .HasKey(x => new
            {
                x.ProductId,
                x.CharacteristicId,
            });

        builder.Entity<StoreCategory>()
            .HasKey(x => new
            {
                x.StoreId,
                x.CategoryId,
            });

        builder.Entity<StoreTag>()
            .HasKey(x => new
            {
                x.StoreId,
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

        builder.Entity<Store>()
            .HasOne(x => x.Photo)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StoreAddress>()
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreAddresses)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StoreCategory>()
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreCategories)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<StoreCategory>()
            .HasOne(x => x.Category)
            .WithMany(x => x.StoreCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<StoreTag>()
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreTags)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StoreTag>()
            .HasOne(x => x.Tag)
            .WithMany(x => x.StoreTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StoreReview>()
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreReviews)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<StoreReview>()
            .HasOne(x => x.User)
            .WithMany(x => x.StoreReviews)
            .HasForeignKey(x => x.UserId)
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
