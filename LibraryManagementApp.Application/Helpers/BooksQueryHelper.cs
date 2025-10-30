using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Queries;

namespace LibraryManagementApp.Application.Helpers;

public static class BooksQueryHelper
{
    public static IQueryable<Book> FilterByTitle(this IQueryable<Book> books, QueryObject queryObject)
    {

        if (!string.IsNullOrWhiteSpace(queryObject.BookTitle))
        {
            books = books.Where(book => book.Title.Contains(queryObject.BookTitle));
        }

        return books;
    }

    public static IQueryable<Book> FilterByAuthorName(this IQueryable<Book> books, QueryObject queryObject)
    {

        if (!string.IsNullOrWhiteSpace(queryObject.AuthorName))
        {
            books = books.Where(book => book.Author != null);
            books = books.Where(book => book.Author!.Name.Contains(queryObject.AuthorName));
        }

        return books;
    }

    public static IQueryable<Book> FilterByPublishingDateRange(this IQueryable<Book> books, QueryObject queryObject)
    {

        if (queryObject.After != null || queryObject.Before != null)
        {
            books = books.Where(book => book.PublishedYear != null);
        }

        if (queryObject.After != null)
        {
            var publishingYearAfter = queryObject.After!.Value.Year;
            books = books.Where(book => book.PublishedYear! > publishingYearAfter);
        }

        if (queryObject.Before != null)
        {
            var publishingYearBefore = queryObject.Before!.Value.Year;
            books = books.Where(book => book.PublishedYear! < publishingYearBefore);
        }

        return books;
    }
}
