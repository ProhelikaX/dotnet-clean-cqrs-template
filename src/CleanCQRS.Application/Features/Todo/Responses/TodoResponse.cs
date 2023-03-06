using CleanCQRS.Application.Core.Responses;

namespace CleanCQRS.Application.Features.Todo.Responses;

public class TodoResponse : Response<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}