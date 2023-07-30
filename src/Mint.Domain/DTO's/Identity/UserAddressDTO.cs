namespace Mint.Domain.DTO_s.Identity;

public class UserAddressFullBindingModel
{
    public Guid? Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }
    
    public DateTimeOffset? CreatedDate { get; set; }
    
    public string? FullAddress { get; set; }
    
    public Country? Country { get; set; }
    
    public string? City { get; set; }
    
    public string? Street { get; set; }
    
    public int? ZipCode { get; set; }
    
    public string? Description { get; set; }
}

public record UserAddressFullViewModel(
    Guid? Id = null,
    string? FullName = null,
    string? Email = null, 
    long? Phone = null,
    DateTimeOffset? CreatedDate = null,
    string? FullAddress = null,
    string? Country = null,
    string? City = null,
    string? Street = null,
    int? ZipCode = null,
    string? Description = null);

public class Country
{
    public int Value { get; set; }

    public string? Label { get; set; }
}
