namespace LibraryManagementApp.Domain.Dtos.Book;

public class BookUpdateRequestDto
{
    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }
}
