namespace Mint.Domain.Models.Base.Interfaces;

public interface IHasKey<T>
{
    T Id { get; set; }
}
