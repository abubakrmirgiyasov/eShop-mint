namespace Mint.WebApp.Telegram.WebHook.Extensions;

public static class ConfigurationManagerExtensions
{
    public static T GetRequiredConfigurationInstance<T>(this ConfigurationManager configurationManager, string sectionPath)
        where T : new()
    {
        var configurationSection = configurationManager.GetRequiredSection(sectionPath);
        var configurationInstance = new T();
        configurationSection.Bind(configurationInstance);
        return configurationInstance;
    }
}
