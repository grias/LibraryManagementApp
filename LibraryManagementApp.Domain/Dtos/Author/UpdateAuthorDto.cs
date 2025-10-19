namespace LibraryManagementApp.Domain.Dtos.Author;

public class UpdateAuthorDto
{
    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
