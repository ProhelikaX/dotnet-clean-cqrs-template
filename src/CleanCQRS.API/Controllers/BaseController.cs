using CleanCQRS.Application.Core.Commands;
using CleanCQRS.Application.Core.Queries;
using CleanCQRS.Domain.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanCQRS.API.Controllers;

[Route("[controller]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    private readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }


    protected async Task<TResponse> Send<TResponse>(ICommand<TResponse> command)
    {
        return await _mediator.Send(command);
    }

    protected async Task Send(ICommand command)
    {
        await _mediator.Send(command);
    }

    protected async Task<TResponse> Send<TResponse>(IQuery<TResponse> query)
    {
        return await _mediator.Send(query);
    }

    protected async Task<IPaginatedList<TResponse>> Send<TResponse>(IPageQuery<TResponse> query)
    {
        return await _mediator.Send(query);
    }
}