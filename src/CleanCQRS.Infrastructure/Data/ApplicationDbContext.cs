using CleanCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanCQRS.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
}