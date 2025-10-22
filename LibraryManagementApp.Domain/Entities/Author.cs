using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }
}
