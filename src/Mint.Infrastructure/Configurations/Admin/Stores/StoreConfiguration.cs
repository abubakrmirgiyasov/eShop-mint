using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Infrastructure.Configurations.Admin.Stores;

internal sealed class StoreConfiguration : IEntityConfiguration<Store, Guid>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder
            .HasIndex(x => x.Url)
            .IsUnique(true);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(StoreData.Stores);
    }
}
