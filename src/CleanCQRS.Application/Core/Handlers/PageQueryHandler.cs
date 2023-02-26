using AutoMapper;
using CleanCQRS.Application.Core.Queries;
using CleanCQRS.Domain.Types;
using CleanCQRS.Domain.UnitOfWorks;
using MediatR;

namespace CleanCQRS.Application.Core.Handlers;

public abstract class
    PageQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, IPaginatedList<TResponse>>
    where TRequest : IPageQuery<TResponse>
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IMapper Mapper { get; }

    protected PageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }


    public abstract Task<IPaginatedList<TResponse>> Handle(TRequest request,
        CancellationToken cancellationToken);
}