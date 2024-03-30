using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Base;

namespace Mint.Domain.Models.Admin.Stores;

public class Storage : Entity<Guid>
{
    public int Quantity { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }
}
