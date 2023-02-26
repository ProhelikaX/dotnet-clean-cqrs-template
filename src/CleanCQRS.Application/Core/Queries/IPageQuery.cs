using CleanCQRS.Domain.Filters;
using CleanCQRS.Domain.Types;
using MediatR;

namespace CleanCQRS.Application.Core.Queries;

public interface IPageQuery<T> : IRequest<IPaginatedList<T>>, IPageFilter
{
}