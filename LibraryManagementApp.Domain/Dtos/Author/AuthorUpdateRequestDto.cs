using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Dtos.Author;

public class AuthorUpdateRequestDto
{
    [Required]
    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
