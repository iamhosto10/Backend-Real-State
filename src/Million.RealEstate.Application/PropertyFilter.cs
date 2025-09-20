namespace Million.RealEstate.Application;

public class PropertyFilter
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SortBy { get; set; } = "Price";
    public bool SortDesc { get; set; } = false;
}
