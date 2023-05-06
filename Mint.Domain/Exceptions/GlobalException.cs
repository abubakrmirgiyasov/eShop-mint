namespace Mint.Domain.Exceptions;

public enum ExceptionCode : int
{
    Base = 1000,
    NotFoundContent = 1001,
    NotFoundUser = 1002,
}

public class GlobalException : Exception
{
    public ExceptionCode Code { get; set; }

    public GlobalException(string message)
        : base(message) { }

    public override string ToString()
    {
        return "";
    }
}
