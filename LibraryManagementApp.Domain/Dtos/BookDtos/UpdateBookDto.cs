namespace LibraryManagementApp.Domain.Dtos.BookDtos;

public class UpdateBookDto
{
    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }
}
