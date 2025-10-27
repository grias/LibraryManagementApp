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
}
