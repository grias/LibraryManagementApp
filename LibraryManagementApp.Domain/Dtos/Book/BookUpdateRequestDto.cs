using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Dtos.Book;

public class BookUpdateRequestDto
{
    [Required]
    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }
}
