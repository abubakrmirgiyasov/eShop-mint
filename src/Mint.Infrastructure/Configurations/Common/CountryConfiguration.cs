using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Common;

namespace Mint.Infrastructure.Configurations.Common;

internal sealed class CountryConfiguration : EntityConfiguration<Country, Guid>
{
    public override void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("countries");

        builder.HasData(CountryData.Countries);
    }
}
