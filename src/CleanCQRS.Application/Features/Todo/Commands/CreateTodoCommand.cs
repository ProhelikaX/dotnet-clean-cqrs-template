using CleanCQRS.Application.Core.Commands;
using CleanCQRS.Application.Features.Todo.Responses;

namespace CleanCQRS.Application.Features.Todo.Commands;

public class CreateTodoCommand : ICommand<TodoResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
}