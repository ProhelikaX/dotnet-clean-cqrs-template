using CleanCQRS.Domain.Entities;

namespace CleanCQRS.Infrastructure.Data;

public static class Seeder
{
    public static void SeedData(this ApplicationDbContext context)
    {
        Console.WriteLine("Seeding data...");

        if (context.Todos.Any())
        {
            Console.WriteLine("Data already seeded");
            return;
        }

        context.Todos.Add(new Todo
        {
            Id = Guid.NewGuid(),
            Title = "Clean the house",
            Description = "Clean the house and do the laundry",
            IsCompleted = false
        });

        context.Todos.Add(new Todo
        {
            Id = Guid.NewGuid(),
            Title = "Buy groceries",
            Description = "Buy groceries for the week",
            IsCompleted = false
        });

        context.Todos.Add(new Todo
        {
            Id = Guid.NewGuid(),
            Title = "Go to the gym",
            Description = "Go to the gym and do some cardio",
            IsCompleted = false
        });

        context.SaveChanges();
    }
}