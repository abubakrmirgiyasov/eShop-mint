using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

/// <summary>
/// Discount Entity Configuration
/// </summary>
internal sealed class DiscountConfiguration : IEntityConfiguration<Discount, Guid>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {

    }
}
