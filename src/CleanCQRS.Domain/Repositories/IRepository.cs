using System.Linq.Expressions;
using CleanCQRS.Domain.Entities;

namespace CleanCQRS.Domain.Repositories;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
{
    IQueryable<TEntity> GetAll();

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(TId id);

    Task<TEntity> AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
}