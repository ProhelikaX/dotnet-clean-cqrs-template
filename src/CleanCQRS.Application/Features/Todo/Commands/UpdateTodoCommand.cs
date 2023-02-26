using CleanCQRS.Application.Core.Commands;

namespace CleanCQRS.Application.Features.Todo.Commands;

public class UpdateTodoCommand: ICommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}