namespace LibraryManagementApp.Domain.Dtos.Author;

public class AuthorResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }

    public int BooksCount { get; set; } = 0;
}
