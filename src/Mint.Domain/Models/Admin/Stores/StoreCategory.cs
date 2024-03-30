using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin.Stores;

namespace Mint.Domain.Models.Stores;

public class StoreCategory
{
    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }
}
