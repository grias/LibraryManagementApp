using LibraryManagementApp.Domain.Dtos.Author;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Interfaces.Services;
using LibraryManagementApp.Domain.Mappers;

namespace LibraryManagementApp.Domain.Services;

public class AuthorsService : IAuthorsService
{
    private readonly IAuthorsRepository _authorsRepository;

    public AuthorsService(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<List<AuthorResponseDto>> GetAllAsync()
    {
        var authorModels = await _authorsRepository.GetAllAsync();
        return authorModels.ToListOfAuthorResponseDtos();
    }

    public async Task<AuthorResponseDto?> GetByIdAsync(int id)
    {
        var authorModel = await _authorsRepository.GetByIdAsync(id);
        if (authorModel is null)
        {
            return null;
        }

        return authorModel.ToAuthorDto();
    }

    public async Task<AuthorResponseDto> CreateAsync(AuthorCreateRequestDto authorDto)
    {
        var createdAuthorModel = await _authorsRepository.CreateAsync(authorDto.ToAuthorModel());
        return createdAuthorModel.ToAuthorDto();
    }
    public async Task<AuthorResponseDto?> TryUpdateAsync(int id, AuthorUpdateRequestDto authorDto)
    {
        var authorModel = await _authorsRepository.GetByIdAsync(id);

        if (authorModel is null)
        {
            return null;
        }

        var updatedAuthorModel = await _authorsRepository.UpdateAsync(authorModel);
        return updatedAuthorModel.ToAuthorDto();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var AuthorModel = await _authorsRepository.GetByIdAsync(id);

        if (AuthorModel is null)
        {
            return false;
        }

        await _authorsRepository.DeleteAsync(id);
        return true;
    }
}
