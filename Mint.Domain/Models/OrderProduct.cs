namespace Mint.Domain.Models;

public class OrderProduct
{
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;
}
