﻿using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните объязательное поле")]
    [MaxLength(100, ErrorMessage = "Перевышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(400, ErrorMessage = "Перевышено макс. длина строки (400).")]
    public string? FullName { get; set; }

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? ExternalLink { get; set; }

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? DefaultLink { get; set; }

    public int DisplayOrder { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public Guid? SubCategoryId { get; set; }

    public SubCategory? SubCategory { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }

    public List<Product>? Products { get; set; }
}