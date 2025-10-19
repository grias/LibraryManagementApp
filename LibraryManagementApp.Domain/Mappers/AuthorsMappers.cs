using LibraryManagementApp.Domain.Dtos.AuthorDtos;
using LibraryManagementApp.Domain.Dtos.BookDtos;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Mappers;

public static class AuthorsMappers
{
    public static AuthorDto ToAuthorDto(this Author authorModel)
    {
        return new AuthorDto()
        {
            Id = authorModel.Id,
            Name = authorModel.Name,
            DateOfBirth = authorModel.DateOfBirth,
        };
    }

    public static Author ToAuthorModel(this CreateAuthorDto authorDto)
    {
        return new Author()
        {
            Name = authorDto.Name,
            DateOfBirth = authorDto.DateOfBirth
        };
    }
}
