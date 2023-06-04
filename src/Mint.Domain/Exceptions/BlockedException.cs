namespace Mint.Domain.Exceptions;

public class BlockedException : Exception
{
    public BlockedException(string message)
        : base(message) { }
}
