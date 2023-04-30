namespace Mint.Domain.Models;

public class Store
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public int ZipCode { get; set; }

    public string? AddressDescription { get; set; }

    public bool IsOwnStorage { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<Product>? Products { get; set; }

    public List<Storage>? Storages { get; set; }

    public List<Order> Orders { get; set; } = null!;
}
