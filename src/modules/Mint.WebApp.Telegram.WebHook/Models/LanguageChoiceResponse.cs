#nullable disable

namespace Mint.WebApp.Telegram.WebHook.Models;

public class LanguageChoiceResponse
{
    public string Code { get; set; }

    public int MessageId { get; set; }

    public LanguageDirection Direction { get; set; }
}

public enum LanguageDirection : byte
{
    Source,
    Target
}
