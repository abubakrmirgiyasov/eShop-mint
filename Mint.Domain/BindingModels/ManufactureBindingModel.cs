using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class ManufactureBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int DisplayOrder { get; set; }

    public string? Description { get; set; }
    
    public string? Folder { get; set; }

    public IFormFile? Photo { get; set; }
}
