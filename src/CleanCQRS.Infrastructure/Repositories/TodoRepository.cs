using CleanCQRS.Domain.Entities;
using CleanCQRS.Domain.Repositories;
using CleanCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Repositories;

public class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Todo> UpdateAndGetTodo()
    {
        var todoToUpdate = await DbSet.Select(x => x).FirstOrDefaultAsync();
    }
}