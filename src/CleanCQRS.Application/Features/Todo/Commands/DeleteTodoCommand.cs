using CleanCQRS.Application.Core.Commands;

namespace CleanCQRS.Application.Features.Todo.Commands;

public class DeleteTodoCommand: ICommand
{
    public Guid Id { get; set; }
}