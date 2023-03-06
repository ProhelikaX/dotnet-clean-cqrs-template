using System.Linq.Expressions;
using CleanCQRS.Domain.Entities;
using CleanCQRS.Domain.Repositories;
using CleanCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(ApplicationDbContext context)
    {
        DbSet = context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbSet.AsNoTracking();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.AnyAsync(predicate);
    }

    public Task<int> CountAsync()
    {
        return DbSet.CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.CountAsync(predicate);
    }
}