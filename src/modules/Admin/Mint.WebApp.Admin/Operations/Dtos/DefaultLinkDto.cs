namespace Mint.WebApp.Admin.Operations.Dtos;

public class DefaultLinkDTO
{
    public Guid Id { get; set; }

    public int DisplayOrder { get; set; }

    public string DefaultLink { get; set; } = default!;
}
