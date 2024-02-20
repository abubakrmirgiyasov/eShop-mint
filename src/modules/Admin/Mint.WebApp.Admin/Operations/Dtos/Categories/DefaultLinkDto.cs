﻿namespace Mint.WebApp.Admin.Operations.Dtos.Categories;

public class DefaultLinkDto
{
    public Guid Id { get; set; }

    public int DisplayOrder { get; set; }

    public string DefaultLink { get; set; } = default!;
}