using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreReviewConfiguration : IEntityConfiguration<StoreReview>
{
    public void Configure(EntityTypeBuilder<StoreReview> builder)
    {
        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreReviews)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.StoreReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
