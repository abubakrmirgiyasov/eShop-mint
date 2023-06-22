using Mint.WebApp.Telegram.WebHook.Interfaces;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class CommandManagerBuilder
{
    private readonly List<ICommand> _commands;
    private readonly IServiceScope _service;

    public CommandManagerBuilder(IServiceScope service)
    {
        _commands = new List<ICommand>();
        _service = service;
    }

    public CommandManagerBuilder RegisterCommand(ICommand command)
    {
        _commands.Add(command);
        return this;
    }

    public CommandManager Build()
    {
        return new CommandManager(_commands, _service);
    }
}
