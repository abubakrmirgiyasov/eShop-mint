namespace Mint.WebApp.Telegram.WebHook.Models;

public class TranslationResponse
{
    public List<Translation> Translations { get; set; } = null!;
}

public class Translation
{
    public string Text { get; set; } = null!;
}