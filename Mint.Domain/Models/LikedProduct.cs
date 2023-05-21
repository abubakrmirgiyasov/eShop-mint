using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class LikedProduct
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime CreateDate { get; set; } = DateTime.Now;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }
}
