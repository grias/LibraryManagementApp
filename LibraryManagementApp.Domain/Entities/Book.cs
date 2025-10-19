using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public int PublishedYear { get; set; }

    public int AuthorId { get; set; }
}
