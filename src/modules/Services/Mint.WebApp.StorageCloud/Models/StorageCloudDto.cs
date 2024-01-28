namespace Mint.WebApp.StorageCloud.Models;

public class StorageCloudDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Bucket { get; set; } = default!;

    public IFormFile Photo { get; set; } = default!;
}
