using System.Net;

namespace LibraryManagementApp.Domain.Exceptions;

public class AuthorNotFoundException : BaseException
{
    public AuthorNotFoundException(int id)
        : base($"Author with id {id} not found", HttpStatusCode.NotFound)
    {
    }
}
