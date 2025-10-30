using LibraryManagementApp.Application.Dtos.Author;
using LibraryManagementApp.Application.Dtos.Book;
using LibraryManagementApp.Domain.Queries;

namespace LibraryManagementApp.Application.Interfaces.Services;

public interface IAuthorsService
{
    Task<List<AuthorResponseDto>> GetAllAsync(QueryObject queryObject);

    Task<AuthorResponseDto> GetByIdAsync(int id);

    Task<List<BookResponseDto>> GetBooksByAuthorIdAsync(int id, QueryObject queryObject);

    Task<AuthorResponseDto> CreateAsync(AuthorCreateRequestDto authorDto);

    Task<AuthorResponseDto> UpdateAsync(int id, AuthorUpdateRequestDto authorDto);

    Task DeleteAsync(int id);
}
