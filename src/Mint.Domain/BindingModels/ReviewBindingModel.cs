using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;

public class ReviewBindingModel
{
    public Guid Id { get; set; }

    public string? Pluses { get; set; }

    public string? Minuses { get; set; }

    public string? Text { get; set; }

    public string? CommentType { get; set; }

    public double Rating { get; set; }

    public DateTime DateCreate { get; set; }

    public string? Type { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? UserId { get; set; }

    public IFormFileCollection? Files { get; set; }
}
