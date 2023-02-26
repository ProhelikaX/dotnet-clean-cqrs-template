using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class GetAllTodoQueryHandler : QueryHandler<GetTodoListQuery, IList<TodoResponse>>
{
    public GetAllTodoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<IList<TodoResponse>> Handle(GetTodoListQuery request,
        CancellationToken cancellationToken)
    {
        var todos = await UnitOfWork.Todo.GetAllAsync();
        return Mapper.Map<IList<TodoResponse>>(todos);
    }
}