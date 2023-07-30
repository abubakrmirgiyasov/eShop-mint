using Mint.Domain.Models;

namespace Mint.Domain.Models.Admin.Categories;

public class ProductPhoto
{
    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }
}
