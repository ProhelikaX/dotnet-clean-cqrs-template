using MediatR;

namespace CleanCQRS.Application.Core.Commands;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
