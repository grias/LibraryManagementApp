using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Application.Dtos.Author;

public class AuthorCreateRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }
}
