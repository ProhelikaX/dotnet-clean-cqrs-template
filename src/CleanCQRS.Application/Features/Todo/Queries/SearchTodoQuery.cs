using CleanCQRS.Application.Core.Queries;
using CleanCQRS.Application.Features.Todo.Responses;

namespace CleanCQRS.Application.Features.Todo.Queries;

public class SearchTodoQuery : IPageQuery<TodoResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public string? SearchTerm { get; set; }
}