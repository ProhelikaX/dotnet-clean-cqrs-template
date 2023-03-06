using CleanCQRS.Domain.Filters;
using CleanCQRS.Domain.Types;

namespace CleanCQRS.Domain.Extensions;

public static class EnumerableExtension
{
    public static IPaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> source, int pageNumber, int pageSize,
        int totalRecords)
    {
        var totalPage = (int)Math.Ceiling(totalRecords / (double)pageSize);
        
        if (pageNumber > totalPage)
        {
            pageNumber = totalPage;
        }

        var validFilter = new PageFilter(pageNumber, pageSize);
        return new PaginatedList<T>(source, validFilter, totalRecords);
    }
}