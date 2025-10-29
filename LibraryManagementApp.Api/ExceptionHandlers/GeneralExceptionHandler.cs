﻿using Microsoft.AspNetCore.Diagnostics;
using LibraryManagementApp.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.Api.ExceptionHandlers;

public class GeneralExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var response = httpContext.Response;

        var problemDetails = new ProblemDetails()
        {
            Title = exception.Message
        };

        if (exception is BaseException baseException)
        {
            response.StatusCode = (int)baseException.StatusCode;
        }

        problemDetails.Status = response.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);

        return true;
    }
}
