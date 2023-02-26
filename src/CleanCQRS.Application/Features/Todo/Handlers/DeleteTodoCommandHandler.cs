using AutoMapper;
using CleanCQRS.Application.Core.Handlers;
using CleanCQRS.Application.Exceptions;
using CleanCQRS.Application.Features.Todo.Commands;
using CleanCQRS.Domain.UnitOfWorks;

namespace CleanCQRS.Application.Features.Todo.Handlers;

public class DeleteTodoCommandHandler : CommandHandler<DeleteTodoCommand>
{
    public DeleteTodoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public override async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await UnitOfWork.Todo.GetByIdAsync(request.Id);

        if (todo == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Todo), request.Id);
        }

        UnitOfWork.Todo.Remove(todo);

        await UnitOfWork.CommitAsync(cancellationToken);
    }
}