using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// User Role Entity Type Configuration
/// </summary>
internal sealed class UserRoleConfiguration : EntityConfiguration<UserRole>
{
    public override void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("user_roles");

        builder.HasKey(x => new
        {
            x.RoleId,
            x.UserId,
        });

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(UserRoleData.UserRoles);
    }
}
