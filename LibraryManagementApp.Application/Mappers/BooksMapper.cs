using LibraryManagementApp.Application.Dtos.Book;
using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Application.Mappers;

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
            AuthorId = bookDto is null || bookDto.AuthorId == 0 ? null : bookDto.AuthorId
        };
    }

    public static Book ToBookModel(this BookUpdateRequestDto bookDto, int id)
    {
        return new Book()
        {
            Id = id,
            Title = bookDto.Title,
            PublishedYear = bookDto.PublishedYear,
            AuthorId = bookDto is null || bookDto.AuthorId == 0 ? null : bookDto.AuthorId
        };
    }

    public static List<BookResponseDto> ToListOfResponseDtos(this List<Book> books)
    {
        return books.Select(book => book.ToBookDto()).ToList();
    }
}
