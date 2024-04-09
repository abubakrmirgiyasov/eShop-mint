using MediatR;
using Microsoft.Extensions.Logging;

namespace Mint.Application;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {TRequest}", typeof(TRequest).Name);

        var response = await next();

        _logger.LogInformation("Handled {TResponse}", typeof(TResponse).Name);

        return response;
    }
}
