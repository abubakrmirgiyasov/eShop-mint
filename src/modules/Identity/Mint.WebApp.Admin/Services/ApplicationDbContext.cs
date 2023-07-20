using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models;
using Mint.WebApp.Admin.Models;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasIndex(x => x.Sku)
            .IsUnique(true);

        builder.Entity<Product>()
            .HasIndex(x => x.Gtin)
            .IsUnique(true);

        builder.Entity<ProductTag>()
            .HasKey(x => new
            {
                x.ProductId,
                x.TagId,
            });

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductPhoto>()
            .HasOne(x => x.Photo)
            .WithMany(x => (List<ProductPhoto>?)x.TEntities)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

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
            .HasOne(x => x.Characteristic)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
