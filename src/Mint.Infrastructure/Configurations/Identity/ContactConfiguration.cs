using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Domain.Common.Data;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Configurations.Identity;

/// <summary>
/// Contact Entity Type Configuration
/// </summary>
internal sealed class ContactConfiguration : IEntityConfiguration<Contact, Guid>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contacts");

        builder
            .Property(x => x.Type)
            .HasConversion<string>();

        builder
            .HasIndex(x => x.ContactInformation)
            .IsUnique(true);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(ContactData.Contacts);
    }
}
