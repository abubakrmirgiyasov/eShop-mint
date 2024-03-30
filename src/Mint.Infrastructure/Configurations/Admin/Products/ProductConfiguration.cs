using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

/// <summary>
/// Products Entity Type Configuration
/// </summary>
internal sealed class ProductConfiguration : IEntityConfiguration<Product, Guid>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .HasIndex(x => x.Sku)
            .IsUnique(true);

        builder
            .HasIndex(x => x.Gtin)
            .IsUnique(true);

        builder
            .HasIndex(x => x.ProductNumber)
            .IsUnique(true);

        builder
            .HasIndex(x => x.UrlToProduct)
            .IsUnique(true);

        builder
            .Property(x => x.ProductNumber)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(x => x.Unit)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Manufacture)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ManufactureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Discount)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.DiscountId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
