﻿#nullable disable

using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Infrastructure.Services;

public class Dispatcher
{
    private readonly IServiceProvider _service;

    public Dispatcher(IServiceProvider service)
    {
        _service = service;
    }

    public async Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] types = { command.GetType() };
        Type handlerType = type.MakeGenericType(types);

        dynamic handler = _service.GetService(handlerType);
        await handler.HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<T> DispatchAsync<T>(IQuery<T> query, CancellationToken cancellationToken = default)
    {
        Type type = typeof(IQueryHandler<,>);
        Type[] types = { query.GetType(), typeof(T) };
        Type handlerType = type.MakeGenericType(types);

        dynamic handler = _service.GetService(handlerType);
        Task<T> result = handler.HandleAsync((dynamic)query, cancellationToken);

        return await result;
    }
}
