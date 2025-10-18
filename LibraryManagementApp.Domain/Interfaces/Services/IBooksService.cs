using LibraryManagementApp.Domain.Dtos.BookDtos;

namespace LibraryManagementApp.Domain.Interfaces.Services
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
