namespace LibraryManagementApp.Domain.Helpers;

public static class PaginationExtensions
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, QueryObject queryObject)
    {
        var pagesToSkip = (queryObject.PageNumber - 1) * queryObject.PageSize;
        entities = entities.Skip(pagesToSkip).Take(queryObject.PageSize);
        return entities;
    }
}
