using Mint.Domain.Common;
using Mint.Domain.Models.Base;

namespace Mint.Domain.Models.Admin.Manufactures;

public class ManufactureContact : Entity<Guid>
{
    public ContactType Type { get; set; }

    public required string ContactInformation { get; set; }

    public Guid ManufactureId { get; set; }

    public Manufacture Manufacture { get; set; } = default!;
}
