using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Telegram.WebHook.Services;
using Telegram.Bot.Types;

namespace Mint.WebApp.Telegram.WebHook.Controllers;

[ApiController]
[Route("[controller]")]
public class BotController : ControllerBase
{
    private readonly ILogger<BotController> _logger;

    public BotController(ILoggerFactory logger)
    {
        _logger = logger.CreateLogger<BotController>();
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] Update update,
        [FromServices] UpdateHandlerServiceBase updateHandler,
        CancellationToken cancellationToken)
    {
        updateHandler.MessageReceived += OnMessageReceived;
        updateHandler.ErrorOccured += OnErrorOccured;
        updateHandler.UnknownUpdateTypeReceived += OnUnknownUpdateTypeReceived;

        await updateHandler.HandleUpdateAsync(update, cancellationToken);

        return Ok();
    }

    private Task OnMessageReceived(Message message, CancellationToken cancellationToken)
    {
        _logger.LogInformation("[Post] Received an update message: {MessageText}", message.Text);
        return Task.CompletedTask;
    }

    private Task OnErrorOccured(Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("[Post] An error occured during processing update: {ErrorMessage} {ExceptionToString}", exception.Message, exception.ToString());
        return Task.CompletedTask;
    }

    private Task OnUnknownUpdateTypeReceived(Update update, CancellationToken cancelToken)
    {
        _logger.LogWarning("[POST] Retrieved update with unsupported type: {UpdateType} ({InternalUpdateType})", update.Type, update.Message?.Type);
        return Task.CompletedTask;
    }
}
