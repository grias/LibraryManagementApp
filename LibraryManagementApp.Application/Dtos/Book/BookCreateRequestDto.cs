using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Application.Dtos.Book;

public class BookCreateRequestDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }
}
