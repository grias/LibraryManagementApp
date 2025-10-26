namespace LibraryManagementApp.Domain.Helpers;

public class QueryObject
{
    private static readonly int _firstPage = 1;
    private static readonly int _defaultPageSize = 5;

    public int PageNumber { get; set; } = _firstPage;

    public int PageSize { get; set; } = _defaultPageSize;

    public string? AuthorName { get; set; }

    public string? BookTitle { get; set; }
}
