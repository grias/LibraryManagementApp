using LibraryManagementApp.Application.Dtos.Book;
using LibraryManagementApp.Domain.Queries;

namespace LibraryManagementApp.Application.Interfaces.Services;

public interface IBooksService
{
    Task<List<BookResponseDto>> GetAllAsync(QueryObject queryObject);

    Task<BookResponseDto> GetByIdAsync(int id);

    Task<BookResponseDto> CreateAsync(BookCreateRequestDto bookDto);

    Task<BookResponseDto> UpdateAsync(int id, BookUpdateRequestDto bookDto);

    Task DeleteAsync(int id);
}
