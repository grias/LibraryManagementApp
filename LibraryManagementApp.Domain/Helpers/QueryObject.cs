using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Helpers;

public class QueryObject
{
    private static readonly int _firstPage = 1;
    private static readonly int _defaultPageSize = 5;

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; } = _firstPage;

    [Range(1, int.MaxValue)]
    public int PageSize { get; set; } = _defaultPageSize;

    public string? AuthorName { get; set; }

    public string? BookTitle { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? Before { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? After { get; set; }
}
