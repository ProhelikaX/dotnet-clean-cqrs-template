namespace CleanCQRS.Application.Core.Responses;

public class Response
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}