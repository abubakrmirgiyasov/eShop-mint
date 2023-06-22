using Mint.WebApp.Telegram.WebHook.Models;
using System.Text.Json;
using Telegram.Bot.Types.ReplyMarkups;

namespace Mint.WebApp.Telegram.WebHook.Utils;

public static class TelegramUtilities
{
    public static InlineKeyboardMarkup ParseLanguageCollectionAsKeyboardMarkup(
        IEnumerable<Language> languages,
        int columns,
        LanguageDirection languageDirection,
        int queryMessageId, JsonSerializerOptions options)
    {
        var buttonList = new List<IEnumerable<InlineKeyboardButton>>();

        var row = new List<InlineKeyboardButton>();

        foreach (var language in languages)
        {
            var callbackData = new LanguageChoiceResponse()
            {
                Code = language.Code,
                MessageId = queryMessageId,
                Direction = languageDirection,
            };

            row.Add(InlineKeyboardButton.WithCallbackData(
                text: language.ToString(),
                callbackData: JsonSerializer.Serialize(
                    value: callbackData,
                    options: options)));

            if (row.Count == columns)
            {
                buttonList.Add(row.ToArray());
                row.Clear();
            }

            if (row.Count > 0)
                buttonList.Add(row.ToArray());
        }

        var markup = new InlineKeyboardMarkup(buttonList);
        return markup;
    }
}
