using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Discount
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public int Percent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ActiveDateUntil { get; set; }

    public List<Product>? Products { get; set; }
}
