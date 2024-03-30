using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

/// <summary>
/// Product Photo Entity Configuration
/// </summary>
internal sealed class ProductPhotoConfiguration : IEntityConfiguration<ProductPhoto>
{
    public void Configure(EntityTypeBuilder<ProductPhoto> builder)
    {
        builder
           .HasKey(x => new
           {
               x.ProductId,
               x.PhotoId,
           });

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
