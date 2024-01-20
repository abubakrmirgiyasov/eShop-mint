using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// User Entity Type Configuration
/// </summary>
internal sealed class UserConfiguration : IEntityConfiguration<User, Guid>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder
            .Property(x => x.Gender)
            .HasConversion<string>();

        builder
            .HasOne(x => x.BackgroundPhoto)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.BackgroundPhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(UserData.Users);
    }
}
