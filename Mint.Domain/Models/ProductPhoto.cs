namespace Mint.Domain.Models;

public class ProductPhoto
{
    public Guid ProductId { get; set; }

    public Product? Product { get; set; }

    public Guid PhotoId { get; set; }

    public Photo? Photo { get; set; }
}
