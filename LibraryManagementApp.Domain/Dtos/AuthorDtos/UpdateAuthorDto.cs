namespace LibraryManagementApp.Domain.Dtos.AuthorDtos;

public class UpdateAuthorDto
{
    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
