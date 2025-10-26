using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Helpers;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IBooksService
{
    Task<List<BookResponseDto>> GetAllAsync(QueryObject queryObject);

    Task<BookResponseDto> GetByIdAsync(int id);

    Task<BookResponseDto> CreateAsync(BookCreateRequestDto bookDto);

    Task<BookResponseDto> UpdateAsync(int id, BookUpdateRequestDto bookDto);

    Task DeleteAsync(int id);
}
