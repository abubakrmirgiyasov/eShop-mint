﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Common;

namespace Mint.Infrastructure.Configurations.Common;

/// <summary>
/// Country Entity Type Configuration
/// </summary>
internal sealed class CountryConfiguration : IEntityConfiguration<Country, Guid>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("countries");

        builder.HasData(CountryData.Countries);
    }
}
