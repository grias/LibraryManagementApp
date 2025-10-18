using LibraryManagementApp.Domain.Dtos.AuthorDtos;

namespace LibraryManagementApp.Domain.Interfaces.Services;

public interface IAuthorsService
{
    Task<List<AuthorDto>> GetAllAsync();

    Task<AuthorDto?> GetByIdAsync(int id);

    Task<AuthorDto> CreateAsync(CreateAuthorDto authorDto);

    Task<AuthorDto?> TryUpdateAsync(int id, UpdateAuthorDto authorDto);

    Task<bool> DeleteAsync(int id);
}
