using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class CategoryFullBindingModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public string? BadgeText { get; set; }

    public string? BadgeStyle { get; set; }

    public int DisplayOrder { get; set; }

    public string? FileType { get; set; }

    public string? SubCategoryId { get; set; }

    public string? ManufactureId { get; set; }

    public string? DefaultLink { get; set; }

    public IFormFile? Photo { get; set; }
}

public class CategoryOnlyBindingModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }
}