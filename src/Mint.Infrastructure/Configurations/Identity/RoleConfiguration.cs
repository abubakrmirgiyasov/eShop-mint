using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

internal sealed class RoleConfiguration : EntityConfiguration<Role, Guid>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder
            .HasIndex(x => x.UniqueKey)
            .IsUnique(true);
    }
}
