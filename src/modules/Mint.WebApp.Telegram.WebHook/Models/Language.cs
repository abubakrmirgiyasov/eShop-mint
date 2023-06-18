namespace Mint.WebApp.Telegram.WebHook.Models;

public class Language
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Flag { get; set; } = null!;

    public override string ToString()
    {
        return $"{Name}{Flag}";
    }
}
