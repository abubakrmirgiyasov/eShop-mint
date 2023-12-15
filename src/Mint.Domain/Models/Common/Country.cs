using Mint.Domain.Models.Base;
using Mint.Domain.Models.Identity;

namespace Mint.Domain.Models.Common;

public class Country : Entity<Guid>
{
    public string Name { get; set; } = default!;

    public string CountryCode { get; set; } = default!;

    public List<UserAddress> UserAddresses { get; set; } = default!;
}
