using System.Net;

namespace LibraryManagementApp.Domain.Exceptions;

public class BookNotFoundException : BaseException
{
    public BookNotFoundException(int id) 
        : base($"Book with id {id} not found", HttpStatusCode.NotFound)
    {
    }
}
