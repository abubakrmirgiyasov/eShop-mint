﻿using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Categories;

public class Category : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? Ico { get; set; }

    [MaxLength(30, ErrorMessage = "Превышено макс. длина строки (30).")]
    public string? BadgeText { get; set; }

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? BadgeStyle { get; set; }

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? DefaultLink { get; set; }

    [MaxLength(800, ErrorMessage = "Превышено макс. длина строки (800).")]
    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }

    public bool ShowOnHomePage { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<SubCategory>? SubCategories { get; set; }

    public List<CategoryTag>? CategoryTags { get; set; }

    public List<ProductCategory>? ProductCategories { get; set; }

    public List<StoreCategory>? StoreCategories { get; set; }

    public List<ManufactureCategory>? ManufactureCategories { get; set; }
}
