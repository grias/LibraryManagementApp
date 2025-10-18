using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagementApp.Domain.Models;
using LibraryManagementApp.Domain.Dtos.BookDtos;

namespace LibraryManagementApp.Domain.Interfaces
{
    public interface IBooksService
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDto?> GetByIdAsync(int id);

        Task<BookDto> CreateAsync(CreateBookDto book);

        Task<(BookDto updatedBook, bool exists)> TryUpdateAsync(int id, UpdateBookDto book);

        Task<bool> DeleteAsync(int id);
    }
}
