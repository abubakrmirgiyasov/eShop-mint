using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Exceptions;

namespace Mint.WebApp.Admin.Helpers;

public class ExceptionToProblemDetailsHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = ConvertToProblemDetails(exception);

        var statusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        httpContext.Response.StatusCode = statusCode;

        return problemDetailsService.TryWriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails,
            }    
        );
    }

    private static ProblemDetails ConvertToProblemDetails(Exception exception)
    {
        return exception switch
        {
            NotFoundException notFoundException => new ProblemDetails
            {
                Title = notFoundException.Message,
                Status = StatusCodes.Status404NotFound
            },
            LogicException logicException => new ProblemDetails
            {
                Title = logicException.Message,
                Status = StatusCodes.Status400BadRequest
            },
            ValidationException validationException => new ProblemDetails
            {
                Title = "Ошибка валидации",
                Status = StatusCodes.Status400BadRequest,
                Detail = validationException.Message,
                Extensions =
                {
                    ["errors"] = validationException
                        .Errors
                        .GroupBy(x => x.PropertyName, x => x.ErrorMessage)
                        .ToDictionary(x => x.Key, x => x.ToList())
                }
            },
            _ => new ProblemDetails
            {
                Title = "Внутренняя ошибка сервера.",
                Status = StatusCodes.Status500InternalServerError,
            }
        };
    }
}
