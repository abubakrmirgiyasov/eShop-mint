using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Mint.WebApp.Telegram.WebHook.Extensions;

namespace Mint.WebApp.Telegram.WebHook.Services;

public abstract partial class UpdateHandlerServiceBase
{
    public delegate Task MessageReceivedEventHandler(Message message, CancellationToken cancellationToken);
    public delegate Task MessageEditedEventHandler(Message message, CancellationToken cancellationToken);
    public delegate Task UnknownUpdateTypeReceivedEventHandler(Update update, CancellationToken cancelToken);
    public delegate Task CallbackQueryReceivedEventHandler(CallbackQuery message, CancellationToken cancelToken);
    public delegate Task ErrorOccuredEventHandler(Exception exception, CancellationToken cancellationToken);

    public event MessageReceivedEventHandler? MessageReceived;
    public event MessageEditedEventHandler? MessageEdited;
    public event UnknownUpdateTypeReceivedEventHandler? UnknownUpdateTypeReceived;
    public event CallbackQueryReceivedEventHandler? CallbackQueryReceived;
    public event ErrorOccuredEventHandler? ErrorOccured;
}

public abstract partial class UpdateHandlerServiceBase
{
    protected readonly ITelegramBotClient BotClient;

    protected UpdateHandlerServiceBase(ITelegramBotClient botClient)
    {
        BotClient = botClient;
    }

    public Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
    {
        var handlers = update.Type switch
        {
            UpdateType.Message when update.Message!.Type == MessageType.Text => MessageReceived?.InvokeAll(handler => handler(update.Message!, cancellationToken)),
            UpdateType.CallbackQuery => CallbackQueryReceived?.InvokeAll(handler => handler(update.CallbackQuery!, cancellationToken)),
            UpdateType.EditedMessage => MessageEdited?.InvokeAll(handler => handler(update.Message!, cancellationToken)),
            _ => UnknownUpdateTypeReceived?.InvokeAll(handler => handler(update, cancellationToken))
        };

        return handlers is not null 
            ? Task.WhenAll(handlers) 
            : Task.CompletedTask;
    }

    public Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
    {
        return ErrorOccured?.Invoke(exception, cancellationToken) ?? Task.CompletedTask;
    }
}
