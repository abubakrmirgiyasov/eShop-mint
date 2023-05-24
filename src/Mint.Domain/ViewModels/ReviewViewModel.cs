namespace Mint.Domain.ViewModels;

public class ReviewViewModel
{
    public Guid Id { get; set; }

    public string? Pluses { get; set; }

    public string? Minuses { get; set; }

    public string? Text { get; set; }

    public double Rating { get; set; }

    public string? FullName { get; set; }

    public DateTime DateCreate { get; set; }

    public Guid? ProductId { get; set; }

    public Guid? UserId { get; set; }

    public List<string>? Photos { get; set; }
}
