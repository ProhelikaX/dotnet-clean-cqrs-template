using System.Linq.Expressions;
using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.Extensions;
using CleanCQRS.Domain.Types;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class SearchTodoQueryHandler : PageQueryHandler<SearchTodoQuery, TodoResponse>
{
    public SearchTodoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<IPaginatedList<TodoResponse>> Handle(SearchTodoQuery request,
        CancellationToken cancellationToken)
    {
        var predicate = (Expression<Func<Domain.Entities.Todo, bool>>)(x =>
            request.SearchTerm == null || x.Title.ToLower().Contains(request.SearchTerm.ToLower()));

        var todos = UnitOfWork.Todo.GetAll()
            .AsPage(request.PageNumber, request.PageSize, predicate)
            .OrderByDescending(x => x.CreatedAt).ToList();

        var todoList = Mapper.Map<IEnumerable<TodoResponse>>(todos);
        var totalRecords =
            await UnitOfWork.Todo.CountAsync(predicate);

        return todoList.ToPaginatedList(request.PageNumber, request.PageSize, totalRecords);
    }
}