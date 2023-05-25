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

    public List<RateViewModel>? RateArr { get; set; }
}

public class RateViewModel
{
    public double[] OneStar { get; set; } = new double[2];

    public double[] SecondStar { get; set; } = new double[2];

    public double[] ThirdStar { get; set; } = new double[2];

    public double[] FourthStar { get; set; } = new double[2];

    public double[] FifthStar { get; set; } = new double[2];

    public int Percentage { get; set; }
}