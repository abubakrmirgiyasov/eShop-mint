using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models;
using Mint.WebApp.Admin.Models;
using Mint.WebApp.Admin.Models.Categories;
using Mint.WebApp.Admin.Models.Products;

namespace Mint.WebApp.Admin.Services;

/// <summary>
/// Admin Application Db Context
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
    /// Products Table
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Photos Table
    /// </summary>
    public DbSet<Photo> Photos { get; set; }

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

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Photo)
            .WithMany(x => (List<ProductPhoto>?)x.TEntities)
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
            .WithMany(x => (List<Manufacture>?)x.TEntities)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Category>()
            .HasOne(x => x.Photo)
            .WithMany(x => (List<Category>?)x.TEntities)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

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
    }
}
