namespace Mint.Domain.ViewModels;

public class AddressViewModel
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? ScondName { get; set; }

    public string? LastName { get; set; }

    public string? FullAddress { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public int ZipCode { get; set; }

    public string? Description { get; set; }
}
