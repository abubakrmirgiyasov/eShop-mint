namespace Mint.Domain.Exceptions;

public class CommandNotRegisteredException : Exception
{
    public CommandNotRegisteredException(string commandName)
        : base($"Command '{commandName}' not registered.") { }
}
