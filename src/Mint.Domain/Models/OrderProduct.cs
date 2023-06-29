using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class OrderProduct : Entity<Guid>
{
    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Percent { get; set; }

    [Required]
    public decimal Sum { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!;
}
