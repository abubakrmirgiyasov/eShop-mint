using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mint.WebApp.Telegram.WebHook.Common;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Mint.WebApp.Telegram.WebHook.Services;

public class WebHookService : IHostedService
{
    private readonly ILogger<WebHookService> _logger;
    private readonly IServiceProvider _service;
    private readonly IOptions<BotConfiguration> _settings;

    private ITelegramBotClient _botClient = default!;

    public WebHookService(ILogger<WebHookService> logger, IServiceProvider service, IOptions<BotConfiguration> settings)
    {
        _logger = logger;
        _service = service;
        _settings = settings;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _service.CreateScope();
        _botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

        var botUtl = $"{_settings.Value.HostAddress}{_settings.Value.Route}";

        try
        {
            await _botClient.SetWebhookAsync(
                url: botUtl,
                secretToken: _settings.Value.SecretToken,
                cancellationToken: cancellationToken,
                allowedUpdates: new[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                    UpdateType.CallbackQuery,
                    UpdateType.Unknown,
                });
            _logger.LogInformation("[POST] Successfully setted Telegram webhook");
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Failed to set telegram webhook: {ErrorMessage}", ex.Message);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _botClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("[POST] Successfully unsetted Telegram webhook");
        }
        catch (Exception ex)
        {
            _logger.LogCritical("[POST] Failed to unset Telegram webhook: {ErrorMessage}", ex.Message);
        }
    }
}
