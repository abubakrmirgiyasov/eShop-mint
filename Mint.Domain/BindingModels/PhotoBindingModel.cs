using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class PhotoFullBindingModel
{
    public string? Path { get; set; }

    public string? Extension { get; set; }

    public string? Folder { get; set; }

    public string? Name { get; set; }

    public IFormFile? File { get; set; }
}
