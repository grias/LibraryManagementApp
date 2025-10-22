using LibraryManagementApp.Domain.Dtos.Author;
using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Mappers;

public static class AuthorsMapper
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
