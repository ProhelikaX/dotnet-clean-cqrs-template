using MediatR;

namespace CleanCQRS.Application.Core.Queries;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}