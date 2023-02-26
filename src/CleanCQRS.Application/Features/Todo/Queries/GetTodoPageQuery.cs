using CleanCQRS.Application.Core.Queries;
using CleanCQRS.Application.Features.Todo.Responses;

namespace CleanCQRS.Application.Features.Todo.Queries;

public class GetTodoPageQuery : IPageQuery<TodoResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}