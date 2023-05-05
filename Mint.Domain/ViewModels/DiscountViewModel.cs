namespace Mint.Domain.ViewModels;

public class DiscountViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Percent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ActiveDateUntil { get; set; }
}
