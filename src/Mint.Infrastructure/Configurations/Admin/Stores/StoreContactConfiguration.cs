using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreContactConfiguration : IEntityConfiguration<StoreContact, Guid>
{
    public void Configure(EntityTypeBuilder<StoreContact> builder)
    {
        builder
            .HasIndex(x => x.ContactInformation)
            .IsUnique(true);

        builder
            .HasOne(x => x.Store)
            .WithMany(x => x.StoreContacts)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
