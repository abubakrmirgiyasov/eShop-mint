using Microsoft.AspNetCore.Http;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

public class CategoryInfoBindingModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Ico { get; set; }

    public string? BadgeStyle { get; set; }

    public string? BadgeText { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }

    public bool ShowOnHomePage { get; set; }

    public string? Folder { get; set; }

    public string? Description { get; set; }

    public DefaultLinkDTO? DefaultLink { get; set; }
}

public class CategoryPhotoDto
{
    public required IFormFile Photo { get; set; }
}

public class CategorySampleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}

public class CategoryInfoViewModel : CategoryInfoBindingModel
{
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? UpdateDateTime { get; set; }
}

public class CategoryFullViewModel : CategoryInfoViewModel
{
    public string? ImagePath { get; set; }

    public List<SubCategorySimpleViewModel>? SubCategories { get; set; }

    public List<TagSampleViewModel>? CategoryTags { get; set; }

    public List<ManufactureSampleViewModel>? Manufactures { get; set; }
}
