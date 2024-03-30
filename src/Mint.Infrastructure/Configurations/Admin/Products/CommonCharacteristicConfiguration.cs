using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Products;

namespace Mint.Infrastructure.Configurations.Admin.Products;

internal sealed class CommonCharacteristicConfiguration : IEntityConfiguration<CommonCharacteristic, Guid>
{
    public void Configure(EntityTypeBuilder<CommonCharacteristic> builder)
    {
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.CommonCharacteristics)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
