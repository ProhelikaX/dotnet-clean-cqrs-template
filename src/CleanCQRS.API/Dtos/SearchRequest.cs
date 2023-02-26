namespace CleanCQRS.API.Dtos;

public class SearchRequest : PageRequest
{
    public string? SearchTerm { get; set; }
}