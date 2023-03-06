using CleanCQRS.Domain.Entities;

namespace CleanCQRS.Domain.Repositories;

public interface ITodoRepository : IRepository<Todo, Guid>
{
}