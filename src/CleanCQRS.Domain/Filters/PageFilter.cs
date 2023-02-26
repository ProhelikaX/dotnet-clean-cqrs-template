namespace CleanCQRS.Domain.Filters;

internal class PageFilter : IPageFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    protected PageFilter()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public PageFilter(int? pageNumber, int? pageSize)
    {
        PageNumber = pageNumber == null ? 1 : pageNumber.Value < 1 ? 1 : pageNumber.Value;

        PageSize = pageSize == null ? 10 : pageSize.Value > 100 ? 100 : pageSize.Value;
    }
}