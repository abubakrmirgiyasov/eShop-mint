using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

internal sealed class UserConfiguration : EntityConfiguration<User, Guid>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(UserData.Users);
    }
}
