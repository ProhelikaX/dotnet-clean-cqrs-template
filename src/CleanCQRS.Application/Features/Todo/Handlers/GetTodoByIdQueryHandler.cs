using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Exceptions;
using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class GetTodoByIdQueryHandler : QueryHandler<GetTodoByIdQuery, TodoResponse>
{
    public GetTodoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<TodoResponse> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await UnitOfWork.Todo.GetByIdAsync(request.Id);

        if (todo == null)
        {
            throw new NotFoundException(nameof(Todo), request.Id);
        }

        return Mapper.Map<TodoResponse>(todo);
    }
}