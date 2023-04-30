using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public int OrderNumber { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;
}
