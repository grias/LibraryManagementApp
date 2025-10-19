using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Dtos.Author;

public class CreateAuthorDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }
}
