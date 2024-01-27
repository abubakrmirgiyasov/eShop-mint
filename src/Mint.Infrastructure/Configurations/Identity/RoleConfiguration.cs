using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// Role Entity Type Configuration
/// </summary>
internal sealed class RoleConfiguration : IEntityConfiguration<Role, Guid>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .HasIndex(x => x.UniqueKey)
            .IsUnique(true);

        builder.HasData(RoleData.Roles);
    }
}
