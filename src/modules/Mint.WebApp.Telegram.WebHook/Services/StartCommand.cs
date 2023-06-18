using Mint.WebApp.Telegram.WebHook.Interfaces;
using Telegram.Bot;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class StartCommand : ICommand
{
    public static string CommandName => "/start";

    public string GetCommandName()
    {
        return CommandName;
    }

    public Task HandleCommand(
        ITelegramBotClient botClient, 
        long chatId,
        CancellationToken cancellationToken, 
        string? arguments = null)
    {
        var message = 
            $"Welcome to test mint order bot. To Get start testetsetstestsetstsetetsetstest";
        return botClient.SendTextMessageAsync(
            chatId: chatId,
            text: message,
            cancellationToken: cancellationToken);
    }
}
