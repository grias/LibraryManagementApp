using LibraryManagementApp.Domain.Dtos.AuthorDtos;

namespace LibraryManagementApp.Domain.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync();

        Task<AuthorDto?> GetByIdAsync(int id);

        Task<AuthorDto> CreateAsync(CreateAuthorDto author);

        Task<(AuthorDto updatedAuthor, bool exists)> TryUpdateAsync(int id, UpdateAuthorDto author);

        Task<bool> DeleteAsync(int id);
    }
}
