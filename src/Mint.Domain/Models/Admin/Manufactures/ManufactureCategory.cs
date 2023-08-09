using Mint.Domain.Models.Admin.Categories;

namespace Mint.Domain.Models.Admin.Manufactures;

public class ManufactureCategory
{
    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }
}
