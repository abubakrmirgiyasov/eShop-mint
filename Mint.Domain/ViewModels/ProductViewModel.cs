﻿namespace Mint.Domain.ViewModels;

public class ProductFullViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? ShortDescription { get; set; }

    public string? FullDescription { get; set; }

    public string? AdminComment { get; set; }

    public bool? ShowOnHomePage { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? Sku { get; set; }

    public string? Gtin { get; set; }

    public decimal Price { get; set; }

    public decimal OldPrice { get; set; }

    public bool IsPublished { get; set; }

    public bool IsFreeTax { get; set; }

    public decimal TaxPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime DateCreate { get; set; } = DateTime.Now;

    public int DeliveryMinDay { get; set; }

    public int DeliveryMaxDay { get; set; }

    public string? Manufacture { get; set; }

    public string? Category { get; set; }

    public string? Store { get; set; }

    public string? Discount { get; set; }

    public CommonCharacteristicFullViewModel? CommonCharacteristic { get; set; }

    public List<string>? Photos { get; set; }
}
