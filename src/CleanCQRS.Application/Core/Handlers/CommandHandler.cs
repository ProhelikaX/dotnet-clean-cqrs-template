using AutoMapper;
using CleanCQRS.Application.Core.Commands;
using CleanCQRS.Domain.UnitOfWorks;
using MediatR;

namespace CleanCQRS.Application.Core.Handlers;

public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest : ICommand
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    protected CommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    protected CommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}