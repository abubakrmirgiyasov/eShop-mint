namespace Mint.WebApp.Admin.Application.Operations.Dtos.Common;

public class DefaultLinkDTO
{
    public Guid Id { get; set; }

    public int DisplayOrder { get; set; }

    public required string DefaultLink { get; set; }
}
