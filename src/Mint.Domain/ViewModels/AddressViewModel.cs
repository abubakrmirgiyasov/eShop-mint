namespace Mint.Domain.ViewModels;

public class AddressViewModel
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public long Phone { get; set; }

    public string? Email { get; set; }

    public string? FullAddress { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public int ZipCode { get; set; }

    public string? Description { get; set; }
}
