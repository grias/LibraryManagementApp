using LibraryManagementApp.Domain.Dtos.Author;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IAuthorsService
{
    Task<List<AuthorResponseDto>> GetAllAsync();

    Task<AuthorResponseDto> GetByIdAsync(int id);

    Task<AuthorResponseDto> CreateAsync(AuthorCreateRequestDto authorDto);

    Task<AuthorResponseDto> UpdateAsync(int id, AuthorUpdateRequestDto authorDto);

    Task<bool> DeleteAsync(int id);
}
