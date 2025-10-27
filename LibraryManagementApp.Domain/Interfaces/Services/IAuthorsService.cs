using LibraryManagementApp.Domain.Dtos.Author;
using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Helpers;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IAuthorsService
{
    Task<List<AuthorResponseDto>> GetAllAsync(QueryObject queryObject);

    Task<AuthorResponseDto> GetByIdAsync(int id);

    Task<List<BookResponseDto>> GetBooksByAuthorIdAsync(int id, QueryObject queryObject);

    Task<AuthorResponseDto> CreateAsync(AuthorCreateRequestDto authorDto);

    Task<AuthorResponseDto> UpdateAsync(int id, AuthorUpdateRequestDto authorDto);

    Task DeleteAsync(int id);
}
