using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin.Manufactures;

namespace Mint.Infrastructure.Configurations.Admin.Manufactures;

internal sealed class ManufactureContactConfiguration : IEntityConfiguration<ManufactureContact, Guid>
{
    public void Configure(EntityTypeBuilder<ManufactureContact> builder)
    {
        builder
            .HasIndex(x => x.ContactInformation)
            .IsUnique(true);

        builder
            .Property(x => x.Type)
            .HasConversion<string>();
    }
}
