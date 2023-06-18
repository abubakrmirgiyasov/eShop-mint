using Mint.WebApp.Telegram.WebHook.Interfaces;
using Mint.WebApp.Telegram.WebHook.Models;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class StubLanguageManager : ILanguageManager
{
    private readonly Language[] _languages =
    {
        new Language()
        {
            Code = "en",
            Name = "English",
            Flag = "\ud83c\uddfa\ud83c\uddf8",
        },
        new()
        {
            Code = "ru",
            Name = "Русский",
            Flag = "\ud83c\uddf7\ud83c\uddfa"
        },
        new()
        {
            Code = "tj",
            Name = "Тоҷикӣ",
            Flag = "\ud83c\uddf9\ud83c\uddef"
        },
    };

    public Task<Language> GetLanguageByCodeAsync(string code)
    {
        return Task.FromResult(_languages.Single(x => x.Code.ToLower().Equals(code.ToLower())));
    }

    public Task<IEnumerable<Language>> GetLanguageCollectionAsync()
    {
        return Task.FromResult<IEnumerable<Language>>(_languages);
    }
}
