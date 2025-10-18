namespace LibraryManagementApp.Domain.Dtos.AuthorDtos;

public class CreateAuthorDto
{
    public string Name { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }
}
