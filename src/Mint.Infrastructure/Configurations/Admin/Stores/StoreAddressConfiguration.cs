using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreAddressConfiguration : IEntityConfiguration<StoreAddress, Guid>
{
    public void Configure(EntityTypeBuilder<StoreAddress> builder)
    {
        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreAddresses)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
