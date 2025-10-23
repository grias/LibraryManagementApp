using LibraryManagementApp.Domain.Dtos.Book;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IBooksService
{
    Task<List<BookResponseDto>> GetAllAsync();

    Task<BookResponseDto> GetByIdAsync(int id);

    Task<BookResponseDto> CreateAsync(BookCreateRequestDto bookDto);

    Task<BookResponseDto> UpdateAsync(int id, BookUpdateRequestDto bookDto);

    Task DeleteAsync(int id);
}
