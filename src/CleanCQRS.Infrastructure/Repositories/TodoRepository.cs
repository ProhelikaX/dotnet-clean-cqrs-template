using CleanCQRS.Domain.Entities;
using CleanCQRS.Domain.Repositories;
using CleanCQRS.Infrastructure.Data;

namespace CleanCQRS.Infrastructure.Repositories;

public class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext context) : base(context)
    {
    }
}