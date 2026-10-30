using System.Net;
using Tacomanda.Application;
using Tacomanda.Domain;

namespace Tacomanda.Api.Middleware;

public sealed class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var status = exception switch
            {
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                RequestValidationException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                ConflictException => HttpStatusCode.Conflict,
                DomainException or ArgumentException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            logger.LogError(
                exception,
                "Request failed: {Method} {Path}; status {StatusCode}",
                context.Request.Method,
                context.Request.Path,
                (int)status);

            if (context.Response.HasStarted) throw;

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(new
            {
                status = (int)status,
                message = "Error en el sistema."
            });
        }
    }
}
