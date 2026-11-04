<<<<<<< HEAD
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
=======
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
>>>>>>> 4c695f795a46a9ec3b62cb63a997060b28afe20a
        }
    }
}
