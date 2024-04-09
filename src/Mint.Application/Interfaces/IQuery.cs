using MediatR;

namespace Mint.Application.Interfaces;

public interface IQuery : IRequest;

public interface IQuery<out TResponse> : IRequest<TResponse>;

public interface IQueryHandler<in TRequest> : IRequestHandler<TRequest>
    where TRequest : IQuery;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>;
