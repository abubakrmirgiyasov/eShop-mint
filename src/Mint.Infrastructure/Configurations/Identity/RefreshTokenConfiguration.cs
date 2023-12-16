﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// Refresh Token Entity Type Configuration
/// </summary>
internal sealed class RefreshTokenConfiguration : EntityConfiguration<RefreshToken, Guid>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
