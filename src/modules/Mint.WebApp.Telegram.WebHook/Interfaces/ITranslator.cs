namespace Mint.WebApp.Telegram.WebHook.Interfaces;

public interface ITranslator
{
    Task<string> TranslateAsync(string fromLanguage, string toLanguage, string text);
}
