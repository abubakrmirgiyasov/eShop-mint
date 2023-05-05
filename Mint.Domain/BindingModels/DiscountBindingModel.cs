namespace Mint.Domain.BindingModels;

public class DiscountBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int Percent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UntilDate { get; set; }
}
