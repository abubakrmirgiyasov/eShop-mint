using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

internal sealed class CharacteristicConfiguration : IEntityConfiguration<Characteristic, Guid>
{
    public void Configure(EntityTypeBuilder<Characteristic> builder)
    {

    }
}
