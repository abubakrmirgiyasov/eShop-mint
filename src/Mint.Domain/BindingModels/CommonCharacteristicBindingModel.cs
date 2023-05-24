namespace Mint.Domain.BindingModels;

public class CommonCharacteristicFullBindingModel
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string? Color { get; set; }

    public string? Material { get; set; }

    public double Rate { get; set; }

    public int Garanty { get; set; }

    public DateTime ReleaseDate { get; set; }

    public bool Availability { get; set; }

    public double Weight { get; set; }

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }
}
