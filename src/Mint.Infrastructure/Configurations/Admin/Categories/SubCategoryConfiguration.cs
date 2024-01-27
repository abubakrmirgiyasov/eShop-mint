using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Categories;

namespace Mint.Infrastructure.Configurations.Admin.Categories;

/// <summary>
/// Sub Category Type Configuration
/// </summary>
internal sealed class SubCategoryConfiguration : IEntityConfiguration<SubCategory, Guid>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder
            .HasIndex(x => x.Name)
            .IsUnique(false);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
