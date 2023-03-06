using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.Extensions;
using CleanCQRS.Domain.Filters;
using CleanCQRS.Domain.Types;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class GetTodoPageQueryHandler : PageQueryHandler<GetTodoPageQuery, TodoResponse>
{
    public GetTodoPageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<IPaginatedList<TodoResponse>> Handle(GetTodoPageQuery request,
        CancellationToken cancellationToken)
    {
        var todos = UnitOfWork.Todo.GetAll()
            .AsPage(request.PageNumber, request.PageSize)
            .OrderByDescending(x => x.CreatedAt).ToList();

        var todoList = Mapper.Map<IEnumerable<TodoResponse>>(todos);
        var totalRecords = await UnitOfWork.Todo.CountAsync();
        return todoList.ToPaginatedList(request.PageNumber, request.PageSize, totalRecords);
    }
}