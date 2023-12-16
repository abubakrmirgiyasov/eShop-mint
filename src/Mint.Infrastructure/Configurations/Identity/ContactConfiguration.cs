using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// Contact Entity Type Configuration
/// </summary>
internal sealed class ContactConfiguration : EntityConfiguration<Contact, Guid>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contacts");

        builder
            .Property(x => x.Type)
            .HasConversion<string>();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(ContactData.Contacts);
    }
}
