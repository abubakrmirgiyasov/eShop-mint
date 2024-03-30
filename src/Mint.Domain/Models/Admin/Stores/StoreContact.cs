using Mint.Domain.Common;
using Mint.Domain.Models.Base;

namespace Mint.Domain.Models.Admin.Stores;

public class StoreContact : Entity<Guid>
{
    public ContactType Type { get; set; }

    public required string ContactInformation { get; set; }

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = default!;
}
