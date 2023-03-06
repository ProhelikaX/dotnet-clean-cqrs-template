namespace CleanCQRS.Application.Core.Responses;

public class Response<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}