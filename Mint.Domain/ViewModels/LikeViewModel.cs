namespace Mint.Domain.ViewModels;

public class LikeViewModel
{
    public Guid? Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ProductId { get; set; }

    public ProductFullViewModel? Product { get; set; }
}
