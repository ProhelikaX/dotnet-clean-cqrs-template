using CleanCQRS.Domain.Filters;

namespace CleanCQRS.Domain.Types;

public class PaginatedList<T> : IPaginatedList<T>
{
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
    public IEnumerable<T> Data { get; set; }

    public PaginatedList(IEnumerable<T> data, IPageFilter validFilter, int totalRecords)
    {
        PageNumber = validFilter.PageNumber;
        PageSize = validFilter.PageSize;
        TotalRecords = totalRecords;
        Data = data;

        var totalPages = totalRecords / (double)validFilter.PageSize;
        var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        HasNext =
            validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages;
        HasPrevious =
            validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages;
        TotalPages = roundedTotalPages;
        TotalRecords = totalRecords;
    }
}