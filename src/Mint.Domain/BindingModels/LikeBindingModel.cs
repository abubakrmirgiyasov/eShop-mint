﻿using Mint.Domain.ViewModels;

namespace Mint.Domain.BindingModels;

public class LikeBindingModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }

    public ProductFullViewModel? Product { get; set; }
}
