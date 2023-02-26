using CleanCQRS.API.Dtos;
using CleanCQRS.Application.Features.Todo.Commands;
using CleanCQRS.Application.Features.Todo.Queries;
using CleanCQRS.Application.Features.Todo.Responses;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Domain.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCQRS.API.Controllers;

/// <summary>
/// Todo controller
/// </summary>
public class TodoController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public TodoController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get all todos
    /// </summary>
    /// <returns>List of TodoResponse</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoResponse>>> Get()
    {
        var query = new GetTodoListQuery();
        var result = await Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Get todo by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>TodoResponse</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoResponse>> Get(Guid id)
    {
        var query = new GetTodoByIdQuery { Id = id };
        var result = await Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Create todo
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TodoResponse>> Post(CreateTodoCommand command)
    {
        var result = await Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Update todo
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateTodoCommand command)
    {
        command.Id = id;
        await Send(command);
        return NoContent();
    }

    /// <summary>
    /// Delete todo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTodoCommand { Id = id };
        await Send(command);
        return NoContent();
    }

    /// <summary>
    /// Get page of todos
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("page")]
    public async Task<ActionResult<IPaginatedList<Todo>>> GetPage([FromQuery] PageRequest request)
    {
        var query = new GetTodoPageQuery { PageNumber = request.PageNumber, PageSize = request.PageSize };
        var result = await Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Search todos
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("search")]
    public async Task<ActionResult<IPaginatedList<TodoResponse>>> Search([FromQuery] SearchRequest request)
    {
        var query = new SearchTodoQuery
            { PageNumber = request.PageNumber, PageSize = request.PageSize, SearchTerm = request.SearchTerm };
        var result = await Send(query);
        return Ok(result);
    }
}