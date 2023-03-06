namespace CleanCQRS.Domain.Entities;

public class Todo : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}