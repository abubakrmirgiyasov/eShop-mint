using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class StoreFullBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int ZipCode { get; set; }

    public string? AddressDescription { get; set; }

    public bool IsOwnStorage { get; set; }

    public string? FileType { get; set; }

    public string? UserId { get; set; }

    public List<CategoryOnlyBindingModel>? Categories { get; set; }

    public IFormFile? Photo { get; set; }
}
