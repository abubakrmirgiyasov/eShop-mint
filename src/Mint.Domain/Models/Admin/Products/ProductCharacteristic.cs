﻿namespace Mint.Domain.Models.Admin.Products;

public class ProductCharacteristic
{
    public Guid? CharacteristicId { get; set; }

    public Characteristic? Characteristic { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }
}
