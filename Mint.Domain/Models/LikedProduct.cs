namespace Mint.Domain.Models;

public class LikedProduct
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }
}
