using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using MediatR;

namespace CleanCQRS.Web.Pages;

public class Todo : BasePageModel
{
    public IEnumerable<TodoResponse> Todos { get; set; }= new List<TodoResponse>();

    public Todo(IMediator mediator) : base(mediator)
    {
    }

    public async Task OnGetAsync()
    {
        Todos = await Send(new GetTodoListQuery());
    }
}