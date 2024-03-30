using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreCategoryConfiguration : IEntityConfiguration<StoreCategory>
{
    public void Configure(EntityTypeBuilder<StoreCategory> builder)
    {
        builder
            .HasKey(x => new
            {
                x.StoreId,
                x.CategoryId
            });

        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreCategories)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.StoreCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
