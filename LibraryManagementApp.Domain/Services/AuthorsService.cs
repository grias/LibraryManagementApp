using LibraryManagementApp.Domain.Dtos.Author;
using LibraryManagementApp.Domain.Interfaces.Repositories;
using LibraryManagementApp.Domain.Interfaces.Services;
using LibraryManagementApp.Domain.Mappers;
using LibraryManagementApp.Domain.Exceptions;
using LibraryManagementApp.Domain.Helpers;

namespace LibraryManagementApp.Domain.Services;

public class AuthorsService : IAuthorsService
{
    private readonly IAuthorsRepository _authorsRepository;

    public AuthorsService(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public async Task<List<AuthorResponseDto>> GetAllAsync(QueryObject queryObject)
    {
        var authorModels = await _authorsRepository.GetAllAsync(queryObject);
        return authorModels.ToListOfAuthorResponseDtos();
    }

    public async Task<AuthorResponseDto> GetByIdAsync(int id)
    {
        var authorModel = await _authorsRepository.GetByIdAsync(id);
        if (authorModel is null)
        {
            throw new AuthorNotFoundException(id);
        }

        return authorModel.ToAuthorDto();
    }

    public async Task<AuthorResponseDto> CreateAsync(AuthorCreateRequestDto authorDto)
    {
        var createdAuthorModel = await _authorsRepository.CreateAsync(authorDto.ToAuthorModel());
        return createdAuthorModel.ToAuthorDto();
    }
    public async Task<AuthorResponseDto> UpdateAsync(int id, AuthorUpdateRequestDto authorDto)
    {
        var authorModel = await _authorsRepository.GetByIdAsync(id);
        if (authorModel is null)
        {
            throw new AuthorNotFoundException(id);
        }

        var updatedAuthorModel = await _authorsRepository.UpdateAsync(authorModel);
        return updatedAuthorModel.ToAuthorDto();
    }

    public async Task DeleteAsync(int id)
    {
        var authorModel = await _authorsRepository.GetByIdAsync(id);
        if (authorModel is null)
        {
            throw new AuthorNotFoundException(id);
        }

        await _authorsRepository.DeleteAsync(id);
    }
}
