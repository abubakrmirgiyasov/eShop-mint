namespace Mint.Domain.BindingModels;

public class OrderFullBindingModel
{
    public Guid Id { get; set; }

    public int OrderNumber { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }

    public string? ShippingType { get; set; }

    public string? PaymentType { get; set; }

    public string? Description { get; set; }

    public Guid AddressId { get; set; }

    public Guid StoreId { get; set; }
}

public class OrderProductBindingModel
{
    public Guid Id { get; set; }

    public int OrderNumber { get; set; }

    public string? PaymentType { get; set; }

    public string? ShippingType { get; set; }

    public string? Description { get; set; }

    public List<OrderProductOnlyBindingModel>? OrderProducts { get; set; }

    public Guid UserId { get; set; }

    public Guid AddressId { get; set; }
}

public class OrderProductOnlyBindingModel
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public decimal Sum { get; set; }

    public int Quantity { get; set; }

    public int Percent { get; set; }

    public Guid StoreId { get; set; }
}