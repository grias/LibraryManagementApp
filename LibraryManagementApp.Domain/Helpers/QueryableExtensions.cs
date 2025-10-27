using LibraryManagementApp.Domain.Entities;

namespace LibraryManagementApp.Domain.Helpers;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, QueryObject queryObject)
    {
        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        entities = entities.Skip(pagesToSkip).Take(queryObject.PageSize);
        return entities;
    }

    public static IQueryable<TEntity> FilterByName<TEntity>(this IQueryable<TEntity> authors, QueryObject queryObject) where TEntity : Author
    {

        if (!string.IsNullOrWhiteSpace(queryObject.AuthorName))
        {
            authors = authors.Where(author => author.Name.Contains(queryObject.AuthorName));
        }

        return authors;
    }

    public static IQueryable<TEntity> FilterByTitle<TEntity>(this IQueryable<TEntity> books, QueryObject queryObject) where TEntity : Book
    {

        if (!string.IsNullOrWhiteSpace(queryObject.BookTitle))
        {
            books = books.Where(book => book.Title.Contains(queryObject.BookTitle));
        }

        return books;
    }

    public static IQueryable<TEntity> FilterByAuthorName<TEntity>(this IQueryable<TEntity> books, QueryObject queryObject) where TEntity : Book
    {

        if (!string.IsNullOrWhiteSpace(queryObject.AuthorName))
        {
            books = books.Where(book => book.Author != null);
            books = books.Where(book => book.Author!.Name.Contains(queryObject.AuthorName));
        }

        return books;
    }

    public static IQueryable<TEntity> FilterByPublishingDateRange<TEntity>(this IQueryable<TEntity> books, QueryObject queryObject) where TEntity : Book
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

    public static IQueryable<TEntity> FilterByDateOfBirthRange<TEntity>(this IQueryable<TEntity> authors, QueryObject queryObject) where TEntity : Author
    {

        if (queryObject.After != null || queryObject.Before != null)
        {
            authors = authors.Where(authors => authors.DateOfBirth != null);
        }

        if (queryObject.After != null)
        {
            authors = authors.Where(authors => authors.DateOfBirth! > queryObject.After!);
        }

        if (queryObject.Before != null)
        {
            authors = authors.Where(authors => authors.DateOfBirth! < queryObject.Before!);
        }

        return authors;
    }
}
