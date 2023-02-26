using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Features.Todo.Commands;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class CreateTodoCommandHandler : CommandHandler<CreateTodoCommand, TodoResponse>
{
    public CreateTodoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task<TodoResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = Mapper.Map<Domain.Entities.Todo>(request);

        todo = await UnitOfWork.Todo.AddAsync(todo);

        await UnitOfWork.CommitAsync(cancellationToken);

        return Mapper.Map<TodoResponse>(todo);
    }
}