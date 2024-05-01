namespace Mint.WebApp.Admin.Application.Operations.Dtos.Discounts;

public class DiscountViewModel
{
    public required Guid Id { get; set; }

    public string? Name { get; set; }

    public required int Percent { get; set; }

    public required DateTime CreatedDate { get; set; }

    public required DateTime ActiveDateUntil { get; set; }
}

public class SimpleDiscountViewModel : SimpleDto
{
    public required DateOnly ActiveDateUntil { get; set; }
}
