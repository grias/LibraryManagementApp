using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Queries;

namespace LibraryManagementApp.Application.Helpers;

public static class QueryHelper
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, QueryObject queryObject)
    {
        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        entities = entities.Skip(pagesToSkip).Take(queryObject.PageSize);
        return entities;
    }

    public static IQueryable<Author> FilterByName(this IQueryable<Author> authors, QueryObject queryObject)
    {

        if (!string.IsNullOrWhiteSpace(queryObject.AuthorName))
        {
            authors = authors.Where(author => author.Name.Contains(queryObject.AuthorName));
        }

        return authors;
    }
}
