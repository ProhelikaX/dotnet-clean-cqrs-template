using System.Linq.Expressions;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Domain.Repositories;
using CleanCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbSet<T> DbSet;

    protected Repository(ApplicationDbContext context)
    {
        DbSet = context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return DbSet.AsNoTracking();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return DbSet.AnyAsync(predicate);
    }

    public Task<int> CountAsync()
    {
        return DbSet.CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return DbSet.CountAsync(predicate);
    }
}