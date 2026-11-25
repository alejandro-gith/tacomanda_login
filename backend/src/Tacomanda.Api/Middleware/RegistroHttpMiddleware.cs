namespace Tacomanda.Api.Middleware;

public sealed class RegistroHttpMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RegistroHttpMiddleware> _logger;

    public RegistroHttpMiddleware(RequestDelegate next, ILogger<RegistroHttpMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        _logger.LogInformation("{Method} {Path} -> {Status}. TraceId: {TraceId}",
            context.Request.Method, context.Request.Path,
            context.Response.StatusCode, context.TraceIdentifier);
    }
}
