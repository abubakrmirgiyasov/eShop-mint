using MediatR;

namespace Mint.Infrastructure.Messaging;

public interface ICommand : IRequest;

public interface ICommand<out TResponse> : IRequest<TResponse>; 
