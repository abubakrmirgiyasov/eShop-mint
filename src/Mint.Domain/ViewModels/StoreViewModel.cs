namespace Mint.Domain.ViewModels;

public class StoreFullViewModel
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

    public string? Photo { get; set; }
}
