using Mint.Domain.Models.Base;

namespace Mint.Domain.Models;

public class LikedProduct : Entity<Guid>
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }
}
