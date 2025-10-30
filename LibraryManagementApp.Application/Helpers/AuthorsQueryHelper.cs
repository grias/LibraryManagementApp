using LibraryManagementApp.Domain.Entities;
using LibraryManagementApp.Domain.Queries;

namespace LibraryManagementApp.Application.Helpers;

public static class AuthorsQueryHelper
{
    public static IQueryable<Author> FilterByDateOfBirthRange(this IQueryable<Author> authors, QueryObject queryObject)
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
