using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Base;

namespace Mint.Domain.Models.Admin;

public class Unit : Entity<Guid>
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    /// <summary>
    /// Identifier of unit by default
    /// </summary>
    public required int DefaultUnitId { get; set; }

    public List<Product>? Products { get; set; }
}
