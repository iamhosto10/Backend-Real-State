namespace Million.RealEstate.Application;

public class PagedResult<T>
{
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    public long Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
