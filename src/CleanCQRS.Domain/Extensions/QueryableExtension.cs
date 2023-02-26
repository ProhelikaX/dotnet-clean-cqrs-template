using System.Linq.Expressions;
using CleanCQRS.Domain.Filters;

namespace CleanCQRS.Domain.Extensions;

public static class QueryableExtension
{

    public static IQueryable<T> ToPaginated<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        var validFilter = new PageFilter(pageNumber, pageSize);
        return query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize);
    }

    public static IQueryable<T> ToPaginated<T>(this IQueryable<T> query, int pageNumber, int pageSize,
        Expression<Func<T, bool>> predicate)
    {
        var validFilter = new PageFilter(pageNumber, pageSize);
        return query.Where(predicate).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize);
    }
}