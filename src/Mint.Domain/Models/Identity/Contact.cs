using Mint.Domain.Common;
using Mint.Domain.Models.Base;

namespace Mint.Domain.Models.Identity;

public class Contact : Entity<Guid>
{
    public string ContactInformation { get; set; } = default!;

    public string? CountryCode { get; set; }

    public ContactType Type { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = default!;
}
