using CleanCQRS.Domain.Repositories;

namespace CleanCQRS.Domain.UnitOfWorks;

public interface IUnitOfWork
{
    void Commit();

    Task CommitAsync();

    Task CommitAsync(CancellationToken cancellationToken);
    ITodoRepository Todo { get; }
}