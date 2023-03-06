namespace CleanCQRS.Domain.Entities;

public abstract class Entity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    protected Entity()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}