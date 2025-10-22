namespace LibraryManagementApp.Domain.Dtos.Author;

public class AuthorUpdateRequestDto
{
    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
