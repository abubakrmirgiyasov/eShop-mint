﻿using MediatR;

namespace Mint.Application.Interfaces;

public interface ICommand : IRequest;

public interface ICommand<out TResponse> : IRequest<TResponse>;

public interface ICommandHandler<in TRequest> : IRequestHandler<TRequest>
    where TRequest : ICommand;

public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>;

