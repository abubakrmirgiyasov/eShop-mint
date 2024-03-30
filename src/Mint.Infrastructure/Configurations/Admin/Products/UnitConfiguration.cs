using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Admin;

namespace Mint.Infrastructure.Configurations.Admin;

internal sealed class UnitConfiguration : IEntityConfiguration<Unit, Guid>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder
            .HasIndex(x => x.Name)
            .IsUnique(true);

        builder
            .Property(x => x.DefaultUnitId)
            .ValueGeneratedOnAdd();
    }
}
