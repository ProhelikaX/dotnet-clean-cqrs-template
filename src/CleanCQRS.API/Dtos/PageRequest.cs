using CleanCQRS.Domain.Filters;

namespace CleanCQRS.API.Dtos;

public class PageRequest : IPageFilter
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}