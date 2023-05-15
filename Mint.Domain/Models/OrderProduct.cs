namespace Mint.Domain.Models;

public class OrderProduct
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int Percent { get; set; }

    public decimal Sum { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;
}
