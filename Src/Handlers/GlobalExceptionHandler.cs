using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WiseBank.Src.Exceptions;

namespace WiseBank.Src.Handlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

        ProblemDetails problemDetails;

        if (exception is BankAccountNotFoundException)
        {
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = exception.Message
            };
        }
        else if (exception is ArgumentException)
        {
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = exception.Message
            };
        }
        else
        {

            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error"
            };
        }


        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}