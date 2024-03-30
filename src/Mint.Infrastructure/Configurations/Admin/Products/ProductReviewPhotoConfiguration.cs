using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

internal sealed class ProductReviewPhotoConfiguration : IEntityConfiguration<ProductReviewPhoto>
{
    public void Configure(EntityTypeBuilder<ProductReviewPhoto> builder)
    {
        builder
            .HasKey(x => new
            {
                x.ProductReviewId,
                x.PhotoId,
            });

        builder
            .HasOne(x => x.ProductReview)
            .WithMany(x => x.ProductReviewPhotos)
            .HasForeignKey(x => x.ProductReviewId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.ProductReviewPhotos)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
