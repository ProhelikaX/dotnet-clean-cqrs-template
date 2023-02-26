namespace CleanCQRS.Domain.Filters;

public interface IPageFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    
}