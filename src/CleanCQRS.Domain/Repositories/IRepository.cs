using System.Linq.Expressions;
using CleanCQRS.Domain.Entities;

namespace CleanCQRS.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetAll();

    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(Guid id);

    Task<T> AddAsync(T entity);

    void Update(T entity);

    void Remove(T entity);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
}