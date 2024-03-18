using Microsoft.AspNetCore.Http;
using Mint.Domain.Common;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;

public class ManufactureFullBindingModel
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public required string Country { get; set; }

    public string? FullAddress { get; set; }

    public string? Website { get; set; }

    public int DisplayOrder { get; set; }

    public string? Folder { get; set; }

    public IFormFile? Photo { get; set; }

    public List<ManufactureContactDto>? Contacts { get; set; }

    public List<ManufactureCategoryBindingModel>? ManufactureCategories { get; set; }

    public List<ManufactureTagBindingModel>? ManufactureTags { get; set; }
}

public class ManufactureContactDto
{
    public required ContactType Type { get; set; }

    public required string ContactInformation { get; set; }
}

public class ManufactureFullViewModel 
{
    public Guid Id { get; set; }

    public int DisplayOrder { get; set; }

    public required string Name { get; set; }

    public required string Country { get; set; }

    public string? FullAddress { get; set; }

    public string? ImagePath { get; set; }

    public string? Website { get; set; }

    public string? Description { get; set; }

    public required List<ManufactureContactDto> Contacts { get; set; }

    public List<ManufactureCategoryFullViewModel>? ManufactureCategories { get; set; }
}
