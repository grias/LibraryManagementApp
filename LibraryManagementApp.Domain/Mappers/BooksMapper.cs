using LibraryManagementApp.Domain.Dtos.Book;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Mappers;

public static class BooksMapper
{
    public static BookResponseDto ToBookDto(this Book bookModel)
    {
        return new BookResponseDto()
        {
            Id = bookModel.Id,
            Title = bookModel.Title,
            PublishedYear = bookModel.PublishedYear,
            AuthorId = bookModel.AuthorId
        };
    }

    public static Book ToBookModel(this BookCreateRequestDto bookDto)
    {
        return new Book()
        {
            Title = bookDto.Title,
            PublishedYear = bookDto.PublishedYear,
            AuthorId = bookDto.AuthorId
        };
    }
}
