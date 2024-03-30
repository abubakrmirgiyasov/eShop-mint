using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Manufactures;

namespace Mint.Infrastructure.Configurations.Admin.Manufactures;

/// <summary>
/// Manufacture Entity Type Configuration
/// </summary>
internal sealed class ManufactureConfiguration : IEntityConfiguration<Manufacture, Guid>
{
    public void Configure(EntityTypeBuilder<Manufacture> builder)
    {
        builder
            .HasIndex(x => x.Name)
            .IsUnique(true);

        builder
            .HasIndex(x => x.Website)
            .IsUnique(true);

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.Manufactures)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
