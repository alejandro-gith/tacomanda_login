using Microsoft.AspNetCore.Diagnostics;
using Tacomanda.Api.Contracts;

namespace Tacomanda.Api.Middleware;

public static class StatusCodeResponder
{
    public static async Task ResponderAsync(StatusCodeContext context)
    {
        await context.HttpContext.Response.WriteAsJsonAsync(new ErrorResponse(
            context.HttpContext.Response.StatusCode,
            "Error en el sistema.",
            context.HttpContext.TraceIdentifier));
    }
}
