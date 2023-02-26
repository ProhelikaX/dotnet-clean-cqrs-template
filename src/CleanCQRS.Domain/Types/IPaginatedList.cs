namespace CleanCQRS.Domain.Types;

public interface IPaginatedList<T>
{
    public int PageNumber { get; }
    public int PageSize { get; }

    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
    public IEnumerable<T> Data { get; set; }
    
}