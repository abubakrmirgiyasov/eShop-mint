using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

/// <summary>
/// Product Tag Entity Configuration
/// </summary>
internal sealed class ProductTagConfiguration : IEntityConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder
           .HasKey(x => new
           {
               x.ProductId,
               x.TagId,
           });

        builder
            .HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
           .HasOne(x => x.Product)
           .WithMany(x => x.ProductTags)
           .HasForeignKey(x => x.ProductId)
           .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
