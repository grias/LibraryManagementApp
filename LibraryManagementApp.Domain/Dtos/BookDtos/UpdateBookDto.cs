using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManagementApp.Domain.Dtos.BookDtos
{
    public class UpdateBookDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public int PublishedYear { get; set; }

        public int AuthorId { get; set; }
    }
}
