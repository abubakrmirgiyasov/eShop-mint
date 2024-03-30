using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

/// <summary>
/// Storage Entity Configuration
/// </summary>
internal sealed class StorageConfiguration : IEntityConfiguration<Storage, Guid>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.Storages)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.Storages)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
