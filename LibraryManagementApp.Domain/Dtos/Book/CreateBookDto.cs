using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Dtos.Book;

public class CreateBookDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public int PublishedYear { get; set; }

    public int AuthorId { get; set; }
}
