using LibraryManagementApp.Domain.Dtos.Author;
using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Helpers.Mappers;

public static class AuthorsMapper
{
    public static AuthorResponseDto ToAuthorDto(this Author authorModel)
    {
        return new AuthorResponseDto()
        {
            Id = authorModel.Id,
            Name = authorModel.Name,
            DateOfBirth = authorModel.DateOfBirth,
        };
    }

    public static Author ToAuthorModel(this AuthorCreateRequestDto authorDto)
    {
        return new Author()
        {
            Name = authorDto.Name,
            DateOfBirth = authorDto.DateOfBirth
        };
    }

    public static Author ToAuthorModel(this AuthorUpdateRequestDto authorDto, int id)
    {
        return new Author()
        {
            Id = id,
            Name = authorDto.Name,
            DateOfBirth = authorDto.DateOfBirth
        };
    }

    public static List<AuthorResponseDto> ToListOfAuthorResponseDtos(this List<Author> authors)
    {
        return authors.Select(author => author.ToAuthorDto()).ToList();
    }
}
