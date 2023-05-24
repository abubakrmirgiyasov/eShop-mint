namespace Mint.Domain.ViewModels;

public class OrderFullViewModel
{
    public Guid Id { get; set; }

    public int OrderNumber { get; set; }

    public string? ShippingType { get; set; }

    public string? PaymentType { get; set; }

    public string? Description { get; set; }

    public DateTime DateCreate { get; set; }

    public List<OrderProductFullViewModel>? OrderProducts { get; set; }
}

public class OrderProductFullViewModel
{
    public int Quantity { get; set; }

    public int Percent { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }

    public StoreFullViewModel? Store { get; set; }

    public ProductFullViewModel? Product { get; set; }
}