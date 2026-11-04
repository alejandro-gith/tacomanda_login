using Microsoft.EntityFrameworkCore;
using Tacomanda.Api.Contracts;
using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Api.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            context.Response.StatusCode = 499;
        }
        catch (Exception exception)
        {
            int status = exception switch
            {
                ValidacionException => 400,
                UnauthorizedAccessException => 401,
                KeyNotFoundException => 404,
                ReglaDeNegocioException => 409,
                DbUpdateConcurrencyException => 409,
                _ => 500
            };

            _logger.LogError(exception, "Fallo HTTP {Status}. TraceId: {TraceId}",
                status, context.TraceIdentifier);
            context.Response.StatusCode = status;
            await context.Response.WriteAsJsonAsync(
                new ErrorResponse(status, "Error en el sistema.", context.TraceIdentifier));
        }
    }
}
