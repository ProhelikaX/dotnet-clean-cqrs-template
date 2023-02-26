using CleanCQRS.Domain.Repositories;
using CleanCQRS.Domain.UnitOfWorks;
using CleanCQRS.Infrastructure.Data;
using CleanCQRS.Infrastructure.Repositories;

namespace CleanCQRS.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Todo = new TodoRepository(_context);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public Task CommitAsync()
    {
        return _context.SaveChangesAsync();
    }

    public Task CommitAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public ITodoRepository Todo { get; }
}