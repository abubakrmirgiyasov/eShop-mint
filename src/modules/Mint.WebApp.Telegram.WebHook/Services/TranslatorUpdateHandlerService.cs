using Mint.Infrastructure.MongoDb.Interfaces;
using Mint.WebApp.Telegram.WebHook.Interfaces;
using Mint.WebApp.Telegram.WebHook.Models;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class TranslatorUpdateHandlerService : UpdateHandlerServiceBase
{
    private readonly ITranslator _translator;
    private readonly ILanguageManager _language;
    private readonly CommandManager _command;
    private readonly JsonSerializerOptions _jsonSerializer;
    private readonly ILogger<TranslatorUpdateHandlerService> _logger;
    private readonly IRepository<Models.User> _repository;

    public TranslatorUpdateHandlerService(
        ITranslator translator, 
        ILanguageManager language,
        ITelegramBotClient botClient,
        CommandManager command,
        JsonSerializerOptions jsonSerializer,
        ILogger<TranslatorUpdateHandlerService> logger,
        IRepository<Models.User> repository)
        : base(botClient)
    {
        _translator = translator;
        _language = language;
        _command = command;
        _jsonSerializer = jsonSerializer;

        MessageReceived += OnMessageReceived;
        MessageEdited += OnMessageReceived;
        UnknownUpdateTypeReceived += OnUnknownUpdateTypeReceived;
        CallbackQueryReceived += OnCallbackQueryReceived;
        _logger = logger;
        _repository = repository;
    }

    private async Task OnMessageReceived(Message message, CancellationToken cancellationToken)
    {
        var chatId = message.Chat.Id;

        _logger.LogDebug("Message: {Message} from: {UserName} Id: {ChatId}", message.Text, chatId, message.Chat.Username);

        _repository.InsertOne(new Models.User()
        {
            ChatId = chatId,
            Message = message.Text,
        });

        if (message.Text!.StartsWith('/'))
        {
            try
            {
                await _command.HandleCommandAsync(
                    command: message.Text, 
                    botClient: BotClient, 
                    chatId: chatId, 
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, cancellationToken);
            }
        }
        else
        {
            await BotClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Source language not selected. Please set source language using {SourceLanguageSetterCommand.CommandName} command",
                cancellationToken: cancellationToken);

            return;
        }
    }
    
    private Task OnUnknownUpdateTypeReceived(Update update, CancellationToken cancelToken)
    {
        return BotClient.SendTextMessageAsync(
            chatId: update.Message!.Chat.Id,
            text: "This message type is not supported. At the moment, only text messages can be translated.",
            cancellationToken: cancelToken);
    }
 
    private async Task OnCallbackQueryReceived(CallbackQuery callbackQuery, CancellationToken cancelToken)
    {
        LanguageChoiceResponse? languageChoiceResponse = default;

        try
        {
            languageChoiceResponse =
                JsonSerializer.Deserialize<LanguageChoiceResponse>(callbackQuery.Data!, _jsonSerializer)!;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex, cancelToken);
        }

        if (languageChoiceResponse is null)
            return;

        var chatId = callbackQuery.Message!.Chat.Id;

        if (languageChoiceResponse.Direction == LanguageDirection.Source)
        {

        }
        else
        {

        }

        var language = await _language.GetLanguageByCodeAsync(languageChoiceResponse.Code);

        await BotClient.EditMessageTextAsync(
            chatId: chatId,
            messageId: languageChoiceResponse.MessageId,
            text: $"{languageChoiceResponse.Direction}language successfully changed to {language}",
            cancellationToken: cancelToken);
    }
}
