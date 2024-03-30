using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

internal sealed class ProductCharacteristicConfiguration : IEntityConfiguration<ProductCharacteristic>
{
    public void Configure(EntityTypeBuilder<ProductCharacteristic> builder)
    {
        builder
            .HasKey(x => new
            {
                x.ProductId,
                x.CharacteristicId
            });

        builder
            .HasOne(x => x.Characteristic)
            .WithMany(x => x.ProductCharacteristics)
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductCharacteristics)
            .HasForeignKey(x => x.CharacteristicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
