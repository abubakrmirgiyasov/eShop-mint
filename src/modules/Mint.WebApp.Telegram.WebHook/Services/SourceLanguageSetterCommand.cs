using Mint.WebApp.Telegram.WebHook.Interfaces;
using Mint.WebApp.Telegram.WebHook.Utils;
using System.Text.Json;
using Telegram.Bot;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class SourceLanguageSetterCommand : ICommand
{
    public static string CommandName => "/set_source_language";

    private readonly ILanguageManager _language;
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly int _replaceKeyboardColumns;

    public SourceLanguageSetterCommand(
        ILanguageManager language,
        JsonSerializerOptions serializerOptions,
        int replaceKeyboardColumns)
    {
        _language = language;
        _serializerOptions = serializerOptions;
        _replaceKeyboardColumns = replaceKeyboardColumns;
    }

    public string GetCommandName()
    {
        return CommandName;
    }

    public async Task HandleCommand(
        ITelegramBotClient botClient, 
        long chatId, 
        CancellationToken cancellationToken, 
        string? arguments = null)
    {
        var messageId = (await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "Processing...",
            cancellationToken: cancellationToken)).MessageId;
        
        var languages = await _language.GetLanguageCollectionAsync();
        
        var replyMarkup = TelegramUtilities.ParseLanguageCollectionAsKeyboardMarkup(
            languages: languages,
            columns: _replaceKeyboardColumns,
            languageDirection: Models.LanguageDirection.Source,
            queryMessageId: messageId,
            options: _serializerOptions);

        await botClient.EditMessageTextAsync(
            chatId: chatId,
            messageId: messageId,
            text: "Choose a source language",
            replyMarkup: replyMarkup,
            cancellationToken: cancellationToken);
    }
}
