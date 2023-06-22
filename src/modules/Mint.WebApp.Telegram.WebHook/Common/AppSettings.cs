#nullable disable

namespace Mint.WebApp.Telegram.WebHook.Common;

public class BotConfiguration : ConfigurationBase
{
    public string BotToken { get; set; }

    public string Route { get; set; }

    public string HostAddress { get; set; }

    public string SecretToken { get; set; }

    public static readonly string SectionPath = nameof(BotConfiguration);

    public override void Validate()
    {
        ValidateNotNull(SectionPath, nameof(BotToken), BotToken);
        ValidateNotNull(SectionPath, nameof(Route), Route);
        ValidateNotNull(SectionPath, nameof(HostAddress), HostAddress);
        ValidateNotNull(SectionPath, nameof(SecretToken), SecretToken);
    }
}

public abstract class ConfigurationBase
{
    public abstract void Validate();

    protected void ValidateNotNull<T>(string sectionPath, string propertyName, T value)
    {
        bool isValid;
        if (value is string temp)
            isValid = !string.IsNullOrWhiteSpace(temp);
        else
            isValid = value is not null;

        if (!isValid)
            throw new InvalidOperationException($"'{sectionPath}:{propertyName}' configuration value is not provided");
    }
}