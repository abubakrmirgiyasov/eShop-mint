using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreTagConfiguration : IEntityConfiguration<StoreTag>
{
    public void Configure(EntityTypeBuilder<StoreTag> builder)
    {
        builder
            .HasKey(x => new
            {
                x.StoreId,
                x.TagId
            });

        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreTags)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Tag)
            .WithMany(x => x.StoreTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
