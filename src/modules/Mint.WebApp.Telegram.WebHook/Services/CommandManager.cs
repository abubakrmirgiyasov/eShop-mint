using Mint.Domain.Exceptions;
using Mint.WebApp.Telegram.WebHook.Interfaces;
using System.CodeDom.Compiler;
using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot;

namespace Mint.WebApp.Telegram.WebHook.Services;

public sealed partial class CommandManager : IDisposable
{
    [GeneratedRegex("\\s{2,}")]
    private static partial Regex GetAnyWhitespaceCharactersPattern();

    private readonly IEnumerable<ICommand> _commands;
    private readonly IServiceScope _service;

    private bool _isDisposed;

    public CommandManager(IEnumerable<ICommand> commands, IServiceScope service)
    {
        _commands = commands;
        _service = service;
    }

    ~CommandManager() 
    {
        Dispose(false);
    }

    public IEnumerable<ICommand> GetRegisteredCommandCollection()
    {
        return _commands;
    }

    public async Task HandleCommandAsync(
        string command,
        ITelegramBotClient botClient,
        long chatId,
        CancellationToken cancellationToken)
    {
        const string whitespace = " ";

        string? arguments = default;
        string commandName;

        try
        {
            var splittedCommand = GetAnyWhitespaceCharactersPattern()
                .Replace(command.Trim(), whitespace)
                .Split(whitespace, StringSplitOptions.RemoveEmptyEntries);
            commandName = splittedCommand.First();

            if (splittedCommand.Length > 1)
            {
                arguments = splittedCommand
                    .Skip(1)
                    .Aggregate(
                        seed: new StringBuilder(),
                        func: (result, argument) => result.Append($"{argument}"),
                        resultSelector => resultSelector.ToString());
            }

            var registerCommand =
                _commands.FirstOrDefault(item => item.GetCommandName().Equals(commandName))
                ?? throw new CommandNotRegisteredException(commandName);

            await registerCommand.HandleCommand(botClient, chatId, cancellationToken, arguments);
        }
        catch (Exception ex)
        {
            throw new CommandParseException(ex.Message);
        }
    }

    private void Dispose(bool needDisposing)
    {
        if (!_isDisposed)
        {
            if (needDisposing)
                _service.Dispose();
            _isDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
