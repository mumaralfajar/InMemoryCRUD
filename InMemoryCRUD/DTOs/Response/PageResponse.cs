namespace InMemoryCRUD.DTOs.Response;

public class PagedResponse<T>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public long TotalItems { get; set; }
    public int TotalPages { get; set; }
    public List<T> Items { get; set; }

    public PagedResponse(int page, int size, long totalItems, int totalPages, List<T> items)
    {
        Page = page;
        Size = size;
        TotalItems = totalItems;
        TotalPages = totalPages;
        Items = items;
    }
}