

using Core.Application.Features.Products.Queries;

namespace Core.Application.DTOs;
public class GetProductsQueryDto
{
    public string? Search { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SortBy { get; set; }
    public string SortDirection { get; set; } = "asc"; // "asc" o "desc"
    public GetProductsQuery ToQuery()
        => new(
            Search: Search,
            Page: Page,
            PageSize: PageSize,
            SortBy: SortBy,
            SortDirection: SortDirection
        );
}

