using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.Infrastructure.Configurations.Admin.Categories;

/// <summary>
/// Category Tag Entity Type Configuration
/// </summary>
internal sealed class CategoryTagConfiguration : IEntityConfiguration<CategoryTag>
{
    public void Configure(EntityTypeBuilder<CategoryTag> builder)
    {
        builder
            .HasKey(x => new
            {
                x.CategoryId,
                x.TagId,
            });

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.CategoryTags)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Tag)
            .WithMany(x => x.CategoryTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
