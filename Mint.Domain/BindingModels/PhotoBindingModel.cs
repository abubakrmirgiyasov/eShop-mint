using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class PhotoFullBindingModel
{
    public string? Extension { get; set; }

    public string? Folder { get; set; }

    public string? Name { get; set; }

    public long Size { get; set; }
}
