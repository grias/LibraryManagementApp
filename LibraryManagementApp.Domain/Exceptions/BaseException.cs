using System.Net;

namespace LibraryManagementApp.Domain.Exceptions;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
            StatusCode = statusCode;
    }
}
