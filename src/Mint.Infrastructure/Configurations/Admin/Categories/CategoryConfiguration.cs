using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.Infrastructure.Configurations.Admin.Categories;

/// <summary>
/// Category Entity Type Configuration
/// </summary>
internal sealed class CategoryConfiguration : IEntityConfiguration<Category, Guid>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasIndex(x => x.DefaultLink)
            .IsUnique(false);

        builder
           .HasIndex(x => x.Name)
           .IsUnique(false);

        builder
            .HasOne(x => x.Photo)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.PhotoId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
