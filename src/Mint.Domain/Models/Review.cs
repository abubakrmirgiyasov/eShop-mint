using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Review : Entity<Guid>
{
    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? Pluses { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? Minuses { get; set; }

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400)")]
    public string? Text { get; set; }

    [MaxLength(255, ErrorMessage = "Превышено макс. длина строки (255)")]
    public string? CommentType { get; set; }

    public double Rating { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public List<ReviewPhoto>? ReviewPhotos { get; set; }
}
