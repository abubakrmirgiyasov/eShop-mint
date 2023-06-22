using Mint.WebApp.Telegram.WebHook.Models;

namespace Mint.WebApp.Telegram.WebHook.Interfaces;

public interface ILanguageManager
{
    Task<IEnumerable<Language>> GetLanguageCollectionAsync();

    Task<Language> GetLanguageByCodeAsync(string code);
}
