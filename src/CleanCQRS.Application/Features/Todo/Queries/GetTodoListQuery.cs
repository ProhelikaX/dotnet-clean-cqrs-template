using CleanCQRS.Application.Core.Queries;
using CleanCQRS.Application.Features.Todo.Responses;

namespace CleanCQRS.Application.Features.Todo.Queries;

public class GetTodoListQuery : IQuery<IList<TodoResponse>>
{
}