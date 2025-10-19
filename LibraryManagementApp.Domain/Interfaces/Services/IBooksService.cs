using LibraryManagementApp.Domain.Dtos.Book;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IBooksService
{
    Task<List<BookDto>> GetAllAsync();

    Task<BookDto?> GetByIdAsync(int id);

    Task<BookDto> CreateAsync(CreateBookDto bookDto);

    Task<BookDto?> TryUpdateAsync(int id, UpdateBookDto bookDto);

    Task<bool> DeleteAsync(int id);
}
