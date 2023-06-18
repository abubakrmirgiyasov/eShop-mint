namespace Mint.Domain.Exceptions;

public class CommandParseException : Exception
{
    public CommandParseException(string details)
        : base($"Error occured during command parsing. Details: {details}") { }
}
