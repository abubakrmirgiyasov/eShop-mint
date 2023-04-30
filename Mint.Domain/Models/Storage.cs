using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Storage
{
    [Key]
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }
}
