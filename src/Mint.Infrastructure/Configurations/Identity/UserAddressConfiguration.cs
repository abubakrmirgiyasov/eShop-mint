using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

internal sealed class UserAddressConfiguration : EntityConfiguration<UserAddress, Guid>
{
    public override void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.ToTable("user_addresses");

        builder
            .HasOne(x => x.Country)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserAddresses)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
