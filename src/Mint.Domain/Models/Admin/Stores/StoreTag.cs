using Mint.Domain.Models.Admin.Stores;
using Mint.Domain.Models.Admin.Tags;

namespace Mint.Domain.Models.Stores;

public class StoreTag
{
    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }

    public Guid? TagId { get; set; }

    public Tag? Tag { get; set; }
}
