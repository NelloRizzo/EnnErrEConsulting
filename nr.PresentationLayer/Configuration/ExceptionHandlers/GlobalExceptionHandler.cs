namespace nr.PresentationLayer.Configuration.ExceptionHandlers
{
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IWebHostEnvironment environment) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken) {
            logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = CreateProblemDetails(httpContext, exception);

            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception) {
            var (statusCode, title) = MapExceptionToProblemDetails(exception);

            var problemDetails = new ProblemDetails {
                Status = statusCode,
                Title = title,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            // Aggiungi dettagli estesi per development
            if (environment.IsDevelopment()) {
                problemDetails.Extensions.TryAdd("stackTrace", exception.StackTrace);
                problemDetails.Extensions.TryAdd("exceptionType", exception.GetType().Name);
            }

            return problemDetails;
        }

        private static (int StatusCode, string Title) MapExceptionToProblemDetails(Exception exception) {
            return exception switch {
                ValidationException => (StatusCodes.Status400BadRequest, "Validation Error"),
                ArgumentException => (StatusCodes.Status400BadRequest, "Bad Request"),
                InvalidOperationException => (StatusCodes.Status400BadRequest, "Invalid Operation"),
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
                FileNotFoundException => (StatusCodes.Status404NotFound, "Not Found"),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Unauthorized"),
                NotImplementedException => (StatusCodes.Status501NotImplemented, "Not Implemented"),
                TimeoutException => (StatusCodes.Status408RequestTimeout, "Request Timeout"),
                _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
            };
        }
    }
}
