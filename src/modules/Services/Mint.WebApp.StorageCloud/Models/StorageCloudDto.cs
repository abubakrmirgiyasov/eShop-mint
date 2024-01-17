namespace Mint.WebApp.StorageCloud.Models;

public class StorageCloudDto
{
    public string Bucket { get; set; } = default!;

    public IFormFile File { get; set; } = default!;
}
